using System.Threading;
using NServiceBus;

public class PersonHandler : IHandleMessages<CreatePerson>
{
    public static int count;

    public void Handle(CreatePerson message)
    {
        Interlocked.Increment(ref count);
    }
}