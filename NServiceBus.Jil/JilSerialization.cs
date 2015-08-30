using Jil;
using NServiceBus.Features;
using NServiceBus.MessageInterfaces;
using NServiceBus.MessageInterfaces.MessageMapper.Reflection;

namespace NServiceBus.Jil
{
    /// <summary>
    /// Uses JSON as the message serialization.
    /// </summary>
    public class JilSerialization : Feature
    {
        internal JilSerialization()
        {
            EnableByDefault();
            Prerequisite(this.ShouldSerializationFeatureBeEnabled, "JilSerialization not enable since serialization definition not detected.");
        }

        /// <summary>
        /// See <see cref="Feature.Setup"/>
        /// </summary>
        protected override void Setup(FeatureConfigurationContext context)
        {
            var container = context.Container;
            container.ConfigureComponent<MessageMapper>(DependencyLifecycle.SingleInstance);
            Options options;
            if (!context.Settings.TryGet(out options))
            {
                options = Options.Default;
            }
            container.ConfigureComponent(builder =>
            {
                var messageMapper = builder.Build<IMessageMapper>();
                return new JsonMessageSerializer(messageMapper,options);
            }, DependencyLifecycle.SingleInstance);
        }
    }
}