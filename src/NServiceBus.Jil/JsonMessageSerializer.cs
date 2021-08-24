using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Jil;
using NServiceBus;
using NServiceBus.MessageInterfaces;
using NServiceBus.Serialization;

class JsonMessageSerializer :
    IMessageSerializer
{
    IMessageMapper messageMapper;
    Func<Stream, TextReader> readerCreator;
    Func<Stream, TextWriter> writerCreator;

    public JsonMessageSerializer(
        IMessageMapper messageMapper,
        Options? options,
        string? contentType,
        Func<Stream, TextReader>? readerCreator,
        Func<Stream, TextWriter>? writerCreator)
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

        if (contentType == null)
        {
            ContentType = ContentTypes.Json;
        }
        else
        {
            ContentType = contentType;
        }


        if (writerCreator == null)
        {
            this.writerCreator = stream => new StreamWriter(stream, Encoding.UTF8, 1024, true);
        }
        else
        {
            this.writerCreator = writerCreator;
        }

        if (readerCreator == null)
        {
            this.readerCreator = stream => new StreamReader(stream, Encoding.UTF8, true, 1024, true);
        }
        else
        {
            this.readerCreator = readerCreator;
        }
    }

    public void Serialize(object message, Stream stream)
    {
        using var streamWriter = writerCreator(stream);
        JSON.Serialize(message, streamWriter, options);
    }

    public object[] Deserialize(Stream stream, IList<Type> messageTypes)
    {
        if (messageTypes == null || !messageTypes.Any())
        {
            throw new("Jil requires message types to be specified");
        }

        var rootTypes = FindRootTypes(messageTypes);
        return rootTypes.Select(rootType =>
            {
                var messageType = GetMappedType(rootType);
                stream.Seek(0, SeekOrigin.Begin);
                using var streamReader = readerCreator(stream);
                return JSON.Deserialize(streamReader, messageType, options);
            })
            .ToArray();
    }

    Type GetMappedType(Type serializedType)
    {
        return messageMapper.GetMappedTypeFor(serializedType) ?? serializedType;
    }


    static IEnumerable<Type> FindRootTypes(IEnumerable<Type> messageTypesToDeserialize)
    {
        Type? currentRoot = null;
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

    public string ContentType { get; }

    Options options;
}