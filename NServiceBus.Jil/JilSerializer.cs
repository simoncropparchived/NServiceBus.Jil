namespace NServiceBus.Jil
{
    using System;
    using Serialization;

    /// <summary>
    /// Defines the capabilities of the JSON serializer
    /// </summary>
    public class JilSerializer : SerializationDefinition
    {
        /// <summary>
        /// <see cref="SerializationDefinition.ProvidedByFeature"/>
        /// </summary>
        protected override Type ProvidedByFeature()
        {
            return typeof(JilSerialization);
        }
    }

}
