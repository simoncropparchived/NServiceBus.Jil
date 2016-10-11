using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NServiceBus;

public class MessageSender
{

    public static async Task SendMessages(IEndpointInstance bus)
    {
        var startNew = Stopwatch.StartNew();
        while (startNew.ElapsedMilliseconds < 10000)
        {
            await bus.SendLocal(PersonCreater.Create());
        }
        Console.WriteLine(PersonHandler.count);
    }
}