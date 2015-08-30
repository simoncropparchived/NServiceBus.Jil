namespace NServiceBus.Jil
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using global::Jil;
    using MessageInterfaces;
    using Serialization;

    /// <summary>
    /// JSON message serializer.
    /// </summary>
    public class JsonMessageSerializer : IMessageSerializer
    {
        IMessageMapper messageMapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public JsonMessageSerializer(IMessageMapper messageMapper, Options options = null)
        {
            this.messageMapper = messageMapper;
            
            if (options == null)
            {
                this.options = Options.Default;
            }
            else
            {
                this.options = options;
            }
        }

        /// <summary>
        /// Serializes the given set of messages into the given stream.
        /// </summary>
        /// <param name="message">Message to serialize.</param>
        /// <param name="stream">Stream for <paramref name="message"/> to be serialized into.</param>
        public void Serialize(object message, Stream stream)
        {
            var streamWriter = new StreamWriter(stream);
            JSON.SerializeDynamic(message, streamWriter, options);
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
            if (messageTypes == null || !messageTypes.Any())
            {
                throw new Exception("Jil requires message types to be specified");
            }
            var rootTypes = FindRootTypes(messageTypes);
            return rootTypes.Select(rootType =>
            {
                var messageType = GetMappedType(rootType);
                stream.Seek(0, SeekOrigin.Begin);
                var streamReader = new StreamReader(stream);
                return JSON.Deserialize(streamReader, messageType, options);
            }).ToArray();
        }

        Type GetMappedType(Type serializedType)
        {
            return messageMapper.GetMappedTypeFor(serializedType) ?? serializedType;
        }


        static IEnumerable<Type> FindRootTypes(IEnumerable<Type> messageTypesToDeserialize)
        {
            Type currentRoot = null;
            foreach (var type in messageTypesToDeserialize)
            {
                if (currentRoot == null)
                {
                    currentRoot = type;
                    yield return currentRoot;
                    continue;
                }
                if (!type.IsAssignableFrom(currentRoot))
                {
                    currentRoot = type;
                    yield return currentRoot;
                }
            }
        }
        /// <summary>
        /// Gets the content type into which this serializer serializes the content to 
        /// </summary>
        public string ContentType
        {
            get { return ContentTypes.Json; }
        }

        Options options;
    }
}