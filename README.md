# CognitiveServices.Translator.Wrapper
Microsoft Cognitive Services wrapper. This code/package tries to cover the version 3 (V3) of the `Translator Text API reference`. Basically, we can have 2,000,000 character translated per month using that API. Also, it provides some feature that other API are not (like what was translated by what within the translate service).

## Cover the following implementations
- [Translate API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-translate?tabs=curl)
    - Likely completed. Further tests are required for some options.
- [Transliterate API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-transliterate?tabs=curl)
    - **Not yet available**
- [Detect API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-detect?tabs=curl)
    - **Not yet available**
- [Break sentence API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-break-sentence?tabs=curl)
    - **Not yet available**
- [Dictionary Lookup API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-dictionary-lookup?tabs=curl)
    - **Not yet available**
- [Dictionary Example API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-dictionary-examples?tabs=curl)
    - **Not yet available**
## How to install
Simply install using the Nuget package manager on your project and search for the `CognitiveServices.Translator.Wrapper` package.

Or, you may simply use the command line and do `Install-Package CognitiveServices.Translator.Wrapper -Version 1.0.0`.

## How to use
A few choices exists, I will be presenting the most common scenario with the DI (Dependency Injection).

## appsettings.json
In the settings, add the following: 
```json
"CognitiveService": {
  "Name": "Doc_Transl_demo",
  "SubscriptionKey": "[Insert Key here]",
  "SubscriptionKeyAlternate": "Second key here"
}
```

### Startup.cs
```csharp
// During the service registration
services.AddCognitiveService(configuration); // where configuration is IConfiguration
services.AddScoped<ITranslate, SampleClassWithInjection>(); // Where ITranslate is your own interface, not something required.
```

### SampleClassWithInjection.cs
```csharp
public class SampleClassWithInjection: ITranslate {
  private readonly ITranslateClient _translateClient;
  private readonly ILogger<SampleClassWithInjection> _logger;

  public SampleClassWithInjection(ITranslateClient translateClient, ILogger<SampleClassWithInjection> logger) {
    _translateClient = translateClient;
    _logger = logger;
  }

  public IList<ResponseBody> TranslateSomething(string text) {
    var response = _translateClient.Translate(
      new RequestContent(text),
      new RequestParameter
      {
        From = "ja", // Optional, will be auto-discovered
        To = new[] { "en" }, // You can translate to multiple language at once.
        IncludeAlignment = true, // Return what was translated by what. (see documentation)
      });

    // response = array of sentenses + array of target language
    _logger.LogDebug(response.First().Translations.First().Text);
    
    return response;
  }
}
```

**By example**: If I send `Aさん`, I wil receive `Mr.A.`. (Better example to come)

## Author(s)
- @Nordes (me)

## License
MIT
