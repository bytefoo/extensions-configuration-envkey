using System;
using Microsoft.Extensions.Configuration;

namespace ByteFoo.Extensions.Configuration.EnvKey
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddEnvKeyConfiguration(
            this IConfigurationBuilder builder,
            Action<EnvKeyConfigurationOptions> action)
        {
            return builder.Add(new EnvKeyConfigurationSource(action));
        }
    }
}