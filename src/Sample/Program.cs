using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Jil;

class Program
{
    static async Task Main()
    {
        var configuration = new EndpointConfiguration("JilSerializerSample");
        configuration.UseSerialization<JilSerializer>();
        configuration.UseTransport<LearningTransport>();
        var endpoint = await Endpoint.Start(configuration);
        var message = new MyMessage
        {
            DateSend = DateTime.Now,
        };
        await endpoint.SendLocal(message);
        Console.WriteLine("Press any key to stop program");
        Console.Read();
        await endpoint.Stop();
    }
}