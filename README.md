# extensions-configuration-envkey

based on: https://github.com/Azure/AppConfiguration-DotnetProvider

```
c.AddEnvKeyConfiguration(e =>
        {
            e.Connect("envKey")
                .MapKeys(s => new ValueTask<string>(s.Replace("_", ":")))
                .MapValues(s => new ValueTask<string>(s.Replace("foo", "bar")))
                .Select("AppSettings*");
        });
```