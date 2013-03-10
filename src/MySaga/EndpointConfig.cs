using System;
using NServiceBus;

namespace MySaga
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, IWantToRunWhenBusStartsAndStops
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .UseTransport<Msmq>()
                .MsmqSubscriptionStorage()
                .InMemorySagaPersister()
                .UseInMemoryTimeoutPersister()
                .UnicastBus();
        }

        public void Start()
        {
            Console.WriteLine("This is the process hosting the saga.");
        }

        public void Stop()
        {
            Console.WriteLine("Stopped.");
        }
    }
}
