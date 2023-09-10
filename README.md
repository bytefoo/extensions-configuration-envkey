# extensions-configuration-envkey

```
c.AddEnvKeyConfiguration(e =>
        {
            e.Connect("envKey")
                .MapKeys(s => new ValueTask<string>(s.Replace("_", ":")))
                .MapValues(s => new ValueTask<string>(s.Replace("foo", "bar")))
                .Select("AppSettings*");
        });
```