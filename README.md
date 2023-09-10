# extensions-configuration-envkey

based on: https://github.com/Azure/AppConfiguration-DotnetProvider

```
using ByteFoo.Extensions.Configuration.EnvKey;

c.AddEnvKeyConfiguration(e =>
        {
            e.Connect("envKey")
                .MapKeys(s => new ValueTask<string>(s.Replace("_", ":")))
                .MapValues(s => new ValueTask<string>(s.Replace("foo", "bar")))
                .Select("AppSettings*");
        });
```