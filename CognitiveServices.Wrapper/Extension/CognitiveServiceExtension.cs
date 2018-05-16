using CognitiveServices.Wrapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CognitiveServices.Wrapper.Extension
{
    public static class CognitiveServiceExtension
    {
        public static IServiceCollection AddCognitiveService(this IServiceCollection services, IConfiguration configuration)
        {
            var cognitiveServiceConfig = new CognitiveServiceConfig();
            configuration.GetSection(CognitiveServiceConfig.SectionName).Bind(cognitiveServiceConfig);
            if (cognitiveServiceConfig == null)
                throw new System.Exception($"The configuration must have the {CognitiveServiceConfig.SectionName} " +
                    $"section. Please read the doc.");

            services.AddSingleton(cognitiveServiceConfig);
            services.AddScoped<ITranslateClient, TranslateClient>(); // Maybe should be a singleton instead?

            return services;
        }
    }
}
