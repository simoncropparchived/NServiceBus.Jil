using System.IO;
using System.Text;
using Jil;
using NServiceBus;
using NServiceBus.Jil;

class Usage
{
    Usage(EndpointConfiguration configuration)
    {
        #region JilSerialization

        configuration.UseSerialization<JilSerializer>();

        #endregion
    }

    void CustomSettings(EndpointConfiguration configuration)
    {
        #region JilCustomSettings

        var options = new Options(
            prettyPrint: true,
            dateFormat: DateTimeFormat.MicrosoftStyleMillisecondsSinceUnixEpoch,
            includeInherited: true);

        var serialization = configuration.UseSerialization<JilSerializer>();
        serialization.Options(options);

        #endregion
    }

    void CustomReader(EndpointConfiguration configuration)
    {
        #region JilCustomReader

        var serialization = configuration.UseSerialization<JilSerializer>();
        serialization.ReaderCreator(stream => new StreamReader(stream, Encoding.UTF8));

        #endregion
    }

    void CustomWriter(EndpointConfiguration configuration)
    {
        #region JilCustomWriter

        var serialization = configuration.UseSerialization<JilSerializer>();
        serialization.WriterCreator(stream => new StreamWriter(stream, Encoding.UTF8));

        #endregion
    }

    void ContentTypeKey(EndpointConfiguration configuration)
    {
        #region JilContentTypeKey

        var serialization = configuration.UseSerialization<JilSerializer>();
        serialization.ContentTypeKey("custom-key");

        #endregion
    }
}