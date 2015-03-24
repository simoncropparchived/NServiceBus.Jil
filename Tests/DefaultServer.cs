namespace NServiceBus.AcceptanceTests.EndpointTemplates
{
    using System.Collections.Generic;
    using NServiceBus.Jil;

    public partial class DefaultServer
    {

        public void SetSerializer(IDictionary<string, string> settings, BusConfiguration builder)
        {
            builder.UseSerialization<JilSerializer>();
        }
    }
}