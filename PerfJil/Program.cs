﻿using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Jil;

class Program
{
    static void Main()
    {
        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        var endpointConfiguration = new EndpointConfiguration("JilSerializer.Perf.Jil");
        endpointConfiguration.UseSerialization<JilSerializer>();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.PurgeOnStartup(true);
        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        endpointConfiguration.UseTransport<MsmqTransport>()
            .ConnectionString("deadLetter=false;journal=false");
        endpointConfiguration.DisableFeature<Audit>();
        endpointConfiguration.SendFailedMessagesTo("error");
        var endpoint = await Endpoint.Start(endpointConfiguration);
        try
        {
            await MessageSender.SendMessages(endpoint);
        }
        finally
        {
            await endpoint.Stop();
        }
    }
}