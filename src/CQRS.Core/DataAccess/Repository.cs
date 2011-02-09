using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using CQRS.Core.Domain;
using Messages.Events;

namespace CQRS.Core.DataAccess
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot, new()
    {
        private readonly CQRSDataContext dataContext;

        public Repository()
        {
            dataContext = new CQRSDataContext();
        }

        public void Save(AggregateRoot aggregate)
        {
            var currentVersion = GetCurrentAggregateVersion(aggregate.Id);

            if (currentVersion == null)
            {
                var newAggregateEntity = new AggregateEntity
                                          {
                                              DataType = aggregate.GetType().ToString(),
                                              AggregateId = aggregate.Id,
                                              Version = aggregate.Version
                                          };

                dataContext.AggregateEntities.InsertOnSubmit(newAggregateEntity);
                dataContext.SubmitChanges();
            }
            else if (currentVersion.Value != aggregate.InitialVersion)
            {
                throw new ConcurrencyException(aggregate.Id, aggregate.Version);
            }
            
            foreach (var @event in aggregate.GetUncommittedChanges())
            {
                var eventEntity = new EventEntity
                                        {
                                            Version = @event.Version,
                                            AggregateId = aggregate.Id,
                                            EventData = Serialize(@event),
                                            EventName = @event.GetType().AssemblyQualifiedName
                                        };

                dataContext.EventEntities.InsertOnSubmit(eventEntity);
            }
            var aggregateEntity = dataContext.AggregateEntities.Single(x => x.AggregateId == aggregate.Id);
            aggregateEntity.Version = aggregate.Version;

            dataContext.SubmitChanges();
        }

        public T LoadById(Guid id)
        {
            var obj = new T();

            var eventEntities = dataContext.EventEntities.Where(x => x.AggregateId == id);
            var events = eventEntities.Select(entity => Deserialize(entity.EventData, Type.GetType(entity.EventName, true, false))).ToList();

            obj.LoadsFromHistory(events);
            return obj;
        }

        private int? GetCurrentAggregateVersion(Guid aggregateId)
        {
            var entity = dataContext.AggregateEntities.FirstOrDefault(x => x.AggregateId == aggregateId);
            return (entity == null) ? (int?) null : entity.Version;
        }

        private static string Serialize(object theObject)
        {
            var sw = new StringWriter();
            var serializer = new XmlSerializer(theObject.GetType());

            serializer.Serialize(sw, theObject);
            return sw.ToString();
        }

        private static IDomainEvent Deserialize(string theObject, Type expectedType)
        {
            var sw = new StringReader(theObject);
            var serializer = new XmlSerializer(expectedType);

            return (IDomainEvent)serializer.Deserialize(sw);
        }
    }
}