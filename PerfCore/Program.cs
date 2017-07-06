using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Features;

class Program
{
    public static void Main()
    {
        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        var endpointConfiguration = new EndpointConfiguration("JilSerializer.Perf.Core");
        endpointConfiguration.UseSerialization<JsonSerializer>();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.PurgeOnStartup(true);
        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        endpointConfiguration.UseTransport<LearningTransport>();
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