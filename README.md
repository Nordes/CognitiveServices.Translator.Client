[![Build status](https://ci.appveyor.com/api/projects/status/78xcqsw08we1y62j?svg=true)](https://ci.appveyor.com/project/Nordes/cognitiveservices-translator-client) [![NuGet](https://img.shields.io/nuget/dt/CognitiveServices.Translator.Client.svg?label=NuGet)](https://www.nuget.org/packages/CognitiveServices.Translator.Client/) ![Nuget](https://img.shields.io/nuget/v/CognitiveServices.Translator.Client)

# CognitiveServices.Translator.Client
Microsoft Cognitive Services client. This code/package tries to cover the version 3 (V3) of the `Translator Text API reference`. Basically, we can have 2,000,000 character translated per month using that API. Also, it provides some feature that other API are not (like what was translated by what within the translate service).

# Target
This library/Nuget package targets the NetStandard 2.0, so you can use it within .Net Core 2.0.

## Cover the following implementations
- [X] [Language API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-languages?tabs=curl)
    - **100%** implemented.
    - **Does not require a Cognitive Services API Key**
    - Require some tests.
    - Cache is not implemented perfectly (not yet using the ETag nor invalidating before a next restart).
- [x] [Translate API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-translate?tabs=curl)
    - **100%** implemented.
    - Demo available at [cstranslatordemo.azurewebsites.net](https://cstranslatordemo.azurewebsites.net/)
    - _Todo: Automated integration tests would be a nice to have in order to detect API changes._
- [ ] [Transliterate API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-transliterate?tabs=curl)
    - **Not yet available**
- [ ] [Detect API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-detect?tabs=curl)
    - **Not yet available**
- [ ] [Break sentence API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-break-sentence?tabs=curl)
    - **Not yet available**
- [ ] [Dictionary Lookup API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-dictionary-lookup?tabs=curl)
    - **Not yet available**
- [ ] [Dictionary Example API](https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-dictionary-examples?tabs=curl)
    - **Not yet available**
## How to install (Nuget)
### Choice 1 Nuget package manager
Simply install using the Nuget package manager on your project and search for the `CognitiveServices.Translator.Client` package.

### Choice 2 use the command line
`Install-Package CognitiveServices.Translator.Client -Version 1.0.0`

## How to use
A few choices exists, I will be presenting the most common scenario with the DI (Dependency Injection).

## appsettings.json
In the settings, add the following: 
```json
"CognitiveServices": {
  "Name": "Doc_Transl_demo",
  "SubscriptionKey": "[Insert Key here]",
  "SubscriptionKeyAlternate": "Second key here",
  "SubscriptionRegion": "[Region here, optional]"
}
```

### Startup.cs
```csharp
// During the service registration
services.AddCognitiveServicesTranslator(configuration); // where configuration is IConfiguration
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

    // response = array of sentences + array of target language
    _logger.LogDebug(response.First().Translations.First().Text);
    
    return response;
  }
}
```

**By example**: If I send `Aさん`, I wil receive `Mr.A.`. (Better example to come)

## Author
- @Nordes (me)

### Contrib
- @dmitriybobrovskiy
- @Phrohdoh

## License
MIT
