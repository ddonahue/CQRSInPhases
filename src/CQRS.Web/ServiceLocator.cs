using CQRS.Core.Commands;

namespace CQRS.Web
{
    public static class ServiceLocator
    {
        public static CommandBus CommandBus { get; set; }
    }
}