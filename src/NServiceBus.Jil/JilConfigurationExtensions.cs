using System;
using System.IO;
using Jil;
using NServiceBus.Configuration.AdvancedExtensibility;
using NServiceBus.Jil;
using NServiceBus.Serialization;
using NServiceBus.Settings;

namespace NServiceBus
{
    /// <summary>
    /// Extensions for <see cref="SerializationExtensions{T}"/> to manipulate how messages are serialized via Jil.
    /// </summary>
    public static class JilConfigurationExtensions
    {
        /// <summary>
        /// Configures the <see cref="Options"/> to use.
        /// </summary>
        /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
        /// <param name="options">The <see cref="Options"/> to use.</param>
        public static void Options(this SerializationExtensions<JilSerializer> config, Options options)
        {
            Guard.AgainstNull(config, nameof(config));
            var settings = config.GetSettings();
            settings.Set(options);
        }

        internal static Options GetOptions(this ReadOnlySettings settings)
        {
            return settings.GetOrDefault<Options>();
        }

        /// <summary>
        /// Configures string to use for <see cref="Headers.ContentType"/> headers.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="ContentTypes.Json"/>.
        /// This setting is required when this serializer needs to co-exist with other json serializers.
        /// </remarks>
        /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
        /// <param name="contentTypeKey">The content type key to use.</param>
        public static void ContentTypeKey(this SerializationExtensions<JilSerializer> config, string contentTypeKey)
        {
            Guard.AgainstNull(config, nameof(config));
            Guard.AgainstNullOrEmpty(contentTypeKey, nameof(contentTypeKey));
            var settings = config.GetSettings();
            settings.Set("NServiceBus.Jil.ContentTypeKey", contentTypeKey);
        }

        internal static string GetContentTypeKey(this ReadOnlySettings settings)
        {
            return settings.GetOrDefault<string>("NServiceBus.Jil.ContentTypeKey");
        }

        /// <summary>
        /// Configures the <see cref="TextReader"/> creator of JSON stream.
        /// </summary>
        /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
        /// <param name="readerCreator">A delegate that creates a <see cref="TextReader"/> for a <see cref="Stream"/>.</param>
        public static void ReaderCreator(this SerializationExtensions<JilSerializer> config, Func<Stream, TextReader> readerCreator)
        {
            Guard.AgainstNull(config, nameof(config));
            Guard.AgainstNull(readerCreator, nameof(readerCreator));
            config.GetSettings().Set("NServiceBus.Jil.ReaderCreator", readerCreator);
        }

        internal static Func<Stream, TextReader> GetReaderCreator(this ReadOnlySettings settings)
        {
            return settings.GetOrDefault<Func<Stream, TextReader>>("NServiceBus.Jil.ReaderCreator");
        }

        /// <summary>
        /// Configures the <see cref="TextWriter"/> creator of JSON stream.
        /// </summary>
        /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
        /// <param name="writerCreator">A delegate that creates a <see cref="TextWriter"/> for a <see cref="Stream"/>.</param>
        public static void WriterCreator(this SerializationExtensions<JilSerializer> config, Func<Stream, TextWriter> writerCreator)
        {
            Guard.AgainstNull(config, nameof(config));
            Guard.AgainstNull(writerCreator, nameof(writerCreator));
            config.GetSettings().Set("NServiceBus.Jil.WriterCreator", writerCreator);
        }

        internal static Func<Stream, TextWriter> GetWriterCreator(this ReadOnlySettings settings)
        {
            return settings.GetOrDefault<Func<Stream, TextWriter>>("NServiceBus.Jil.WriterCreator");
        }
    }
}