using NServiceBus;

namespace Messages.Events
{
    public interface IDomainEvent : IMessage
    {
        int Version { get; set; }
    }
}