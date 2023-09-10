using System;
using Microsoft.Extensions.Configuration;

namespace ByteFoo.Extensions.Configuration.EnvKey
{
    public class EnvKeyConfigurationSource : IConfigurationSource
    {
        private readonly Func<EnvKeyConfigurationOptions> _optionsProvider;

        public EnvKeyConfigurationSource(Action<EnvKeyConfigurationOptions> optionsInitializer)
        {
            _optionsProvider = () =>
            {
                var options = new EnvKeyConfigurationOptions();
                optionsInitializer(options);
                return options;
            };
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new EnvKeyConfigurationProvider(_optionsProvider());
        }
    }
}