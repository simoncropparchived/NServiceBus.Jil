using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Jil;

class Program
{
    static void Main(string[] args)
    {
        var busConfig = new BusConfiguration();
        busConfig.EndpointName("JilSerializer.Perf.Jil");
        busConfig.UseSerialization<JilSerializer>();
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