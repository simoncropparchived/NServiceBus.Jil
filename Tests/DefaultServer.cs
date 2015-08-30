using Jil;

namespace NServiceBus.AcceptanceTests.EndpointTemplates
{
    using System.Collections.Generic;
    using Jil;

    public partial class DefaultServer
    {

        public void SetSerializer(IDictionary<string, string> settings, BusConfiguration builder)
        {
            var options = new Options(
                dateFormat: DateTimeFormat.MicrosoftStyleMillisecondsSinceUnixEpoch,
                includeInherited: true);

            builder.UseSerialization<JilSerializer>().Options(options);
        }
    }
}