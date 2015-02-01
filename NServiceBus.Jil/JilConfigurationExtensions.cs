namespace NServiceBus
{
    using System;
    using global::Jil;
    using NServiceBus.Configuration.AdvanceExtensibility;
    using NServiceBus.Jil;
    using NServiceBus.Serialization;

    public static class JilConfigurationExtensions
    {

        /// <summary>
        /// Configures the <see cref="Options"/> to use.
        /// </summary>
        /// <param name="config">The configuration object.</param>
        /// <param name="options">The <see cref="Options"/> to use.</param>
        public static void Options(this SerializationExtentions<JilSerializer> config, Options options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }
            config.GetSettings()
                .SetProperty<JsonMessageSerializer>(s => s.Options, options);
        }
    }
}