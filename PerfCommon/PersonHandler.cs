using System.Threading;
using System.Threading.Tasks;
using NServiceBus;

public class PersonHandler : IHandleMessages<CreatePerson>
{
    public static int count;

    public Task Handle(CreatePerson message, IMessageHandlerContext context)
    {
        Interlocked.Increment(ref count);
        return Task.FromResult(0);
    }
}