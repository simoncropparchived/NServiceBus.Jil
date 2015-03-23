namespace NServiceBus.Jil
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using global::Jil;
    using NServiceBus.Serialization;

    /// <summary>
    /// JSON message serializer.
    /// </summary>
    public class JsonMessageSerializer : IMessageSerializer
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public JsonMessageSerializer()
        {
            Options = JSON.GetDefaultOptions();
        }

        /// <summary>
        /// Serializes the given set of messages into the given stream.
        /// </summary>
        /// <param name="message">Message to serialize.</param>
        /// <param name="stream">Stream for <paramref name="message"/> to be serialized into.</param>
        public void Serialize(object message, Stream stream)
        {
            var streamWriter = new StreamWriter(stream);
            JSON.Serialize(message, streamWriter, Options);
            streamWriter.Flush();
        }

        /// <summary>
        /// Deserializes from the given stream a set of messages.
        /// </summary>
        /// <param name="stream">Stream that contains messages.</param>
        /// <param name="messageTypes">The list of message types to deserialize. If null the types must be inferred from the serialized data.</param>
        /// <returns>Deserialized messages.</returns>
        public object[] Deserialize(Stream stream, IList<Type> messageTypes)
        {
            if (messageTypes.Count > 1)
            {
                throw new Exception("Batch messages are not supported. Feel free to send a Pull Request.");
            }
            var streamReader = new StreamReader(stream);
            return new[]
                   {
                       JSON.Deserialize(streamReader, messageTypes.First(), Options)
                   };
        }

        /// <summary>
        /// Gets the content type into which this serializer serializes the content to 
        /// </summary>
        public string ContentType
        {
            get { return ContentTypes.Json; }
        }

        public Options Options { get; set; }
    }
}