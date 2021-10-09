using NServiceBus;
using NServiceBus.Jil;

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