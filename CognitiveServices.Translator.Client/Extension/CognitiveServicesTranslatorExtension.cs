using CognitiveServices.Translator.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CognitiveServices.Translator.Extension
{
    public static class CognitiveServicesTranslatorExtension
    {
        public static IServiceCollection AddCognitiveServicesTranslator(this IServiceCollection services, IConfiguration configuration)
        {
            var cognitiveServiceConfig = new CognitiveServicesConfig();
            configuration.GetSection(CognitiveServicesConfig.SectionName).Bind(cognitiveServiceConfig);
            if (cognitiveServiceConfig == null)
            {
                throw new System.Exception($"The configuration must have the {CognitiveServicesConfig.SectionName} " +
                    $"section. Please read the doc.");
            }

            services.AddSingleton(cognitiveServiceConfig);
            services.AddScoped<ITranslateClient, TranslateClient>(); // Maybe should be a singleton instead?

            return services;
        }
    }
}
