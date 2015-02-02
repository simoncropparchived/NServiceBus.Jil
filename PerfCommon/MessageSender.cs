using System;
using System.Diagnostics;
using NServiceBus;

public class MessageSender
{

    public static void SendMessages(IStartableBus bus)
    {
        var startNew = Stopwatch.StartNew();
        while (startNew.ElapsedMilliseconds < 10000)
        {
            bus.SendLocal(PersonCreater.Create());
        }
        Console.WriteLine(PersonHandler.count);
    }
}