using NServiceBus.Features;
using NServiceBus.MessageInterfaces.MessageMapper.Reflection;
using NServiceBus.ObjectBuilder;

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
            var c = container.ConfigureComponent<JsonMessageSerializer>(DependencyLifecycle.SingleInstance);

            context.Settings.ApplyTo<JsonMessageSerializer>((IComponentConfig)c);
        }
    }
}