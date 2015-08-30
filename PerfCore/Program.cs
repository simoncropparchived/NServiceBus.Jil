using NServiceBus;
using NServiceBus.Features;

class Program
{
    static void Main()
    {
        var busConfig = new BusConfiguration();
        busConfig.EndpointName("JilSerializer.Perf.Core");
        busConfig.UseSerialization<JsonSerializer>();
        busConfig.EnableInstallers();
        busConfig.PurgeOnStartup(true);
        busConfig.UsePersistence<InMemoryPersistence>();
        busConfig.UseTransport<MsmqTransport>().ConnectionString("deadLetter=false;journal=false");
        busConfig.DisableFeature<Audit>();
        using (var bus = Bus.Create(busConfig))
        {
            bus.Start();
            MessageSender.SendMessages(bus);
        }
    }
}