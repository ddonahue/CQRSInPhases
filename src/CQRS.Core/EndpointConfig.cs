using NServiceBus;

namespace CQRS.Core
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher
    {
    }
}