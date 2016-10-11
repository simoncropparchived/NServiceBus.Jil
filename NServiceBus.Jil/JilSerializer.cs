using NServiceBus.MessageInterfaces;
using NServiceBus.Settings;

namespace NServiceBus.Jil
{
    using System;
    using Serialization;

    /// <summary>
    /// Defines the capabilities of the Jil serializer
    /// </summary>
    public class JilSerializer : SerializationDefinition
    {
        /// <summary>
        /// <see cref="SerializationDefinition.Configure"/>
        /// </summary>
        public override Func<IMessageMapper, IMessageSerializer> Configure(ReadOnlySettings settings)
        {
            return mapper =>
            {
                var readerCreator = settings.GetReaderCreator();
                var writerCreator = settings.GetWriterCreator();
                var options = settings.GetOptions();
                var contentTypeKey = settings.GetContentTypeKey();
                return new JsonMessageSerializer(mapper, options, contentTypeKey, readerCreator, writerCreator);
            };

        }
    }
}