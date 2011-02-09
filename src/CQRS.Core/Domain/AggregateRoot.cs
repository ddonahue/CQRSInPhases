using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Core.Helpers;
using Messages.Events;

namespace CQRS.Core.Domain
{
    public abstract class AggregateRoot
    {
        private readonly List<IDomainEvent> changes = new List<IDomainEvent>();
        public int InitialVersion { get; internal set; }

        public abstract Guid Id { get; }
        public int Version { get; internal set; }

        public IEnumerable<IDomainEvent> GetUncommittedChanges()
        {
            return changes;
        }

        public void MarkChangesAsCommitted()
        {
            changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<IDomainEvent> history)
        {
            foreach (var e in history) ApplyChange(e, false);
            
            InitialVersion = (history.Any()) ? history.OrderByDescending(x => x.Version).First().Version : 0;
        }

        protected void ApplyChange(IDomainEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(IDomainEvent @event, bool isNew)
        {
            this.AsDynamic().Apply(@event);
            if (isNew) changes.Add(@event);
        }
    }
}