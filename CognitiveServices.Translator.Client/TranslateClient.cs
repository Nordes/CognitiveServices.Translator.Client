﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CognitiveServices.Translator.Configuration;
using CognitiveServices.Translator.Translate;
using Newtonsoft.Json;

namespace CognitiveServices.Translator
{
    /// <summary>
    /// Translate using cognitive service from Microsoft
    /// </summary>
    /// <seealso cref="ITranslateClient" />
    /// <remarks>https://docs.microsoft.com/en-us/azure/cognitive-services/translator/quickstarts/csharp</remarks>
    public class TranslateClient : ITranslateClient
    {
        private const int MaxNumberOfRequestContent = 100;
        private const int MaxNumberOfCharacterPerRequest = 5_000;
        private const string UriExtensionPath = "translate";

        private readonly CognitiveServicesConfig _cognitiveServiceConfig = new CognitiveServicesConfig();
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslateClient" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="cognitiveServiceConfig">The cognitive service configuration.</param>
        public TranslateClient(CognitiveServicesConfig cognitiveServiceConfig)
        {
            _cognitiveServiceConfig = cognitiveServiceConfig;

            // In Core 2.1, we can use what is described in: https://docs.microsoft.com/en-gb/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.1
            // Otherwise, maybe use RestSharp?
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Constants.TranslatorApiBasePath)
            };
        }

        /// <summary>
        /// Translates the content.
        /// </summary>
        /// <param name="content">The content. (Max.: 100 items)</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The translated content
        /// </returns>
        public IList<ResponseBody> Translate(IEnumerable<RequestContent> content, RequestParameter options)
        {
            return TranslateAsync(content, options).Result;
        }

        /// <summary>
        /// Translates the content.
        /// </summary>
        /// <param name="content">The content. (Max.: 100 items)</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The translated content
        /// </returns>
        public IList<ResponseBody> Translate(RequestContent content, RequestParameter options)
        {
            return TranslateAsync(new[] { content }, options).Result;
        }

        /// <summary>
        /// Translates the content.
        /// </summary>
        /// <param name="content">The content. (Max.: 100 items)</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The translated content
        /// </returns>
        public async Task<IList<ResponseBody>> TranslateAsync(IEnumerable<RequestContent> content, RequestParameter options)
        {
            if (content.Count() > MaxNumberOfRequestContent)
                throw new Exception($"Maximum amount of text to be translated have been reached (Max: {MaxNumberOfRequestContent})");
            else if (string.Join(string.Empty, content).Length > MaxNumberOfCharacterPerRequest)
                throw new Exception($"Maximum length of all the text to be translated is {MaxNumberOfCharacterPerRequest} characters.");

            var qs = options.ToQueryString();

            using (var request = new HttpRequestMessage(HttpMethod.Post, $"{UriExtensionPath}?{qs}"))
            {
                var requestBody = JsonConvert.SerializeObject(content.ToList());

                // For the request, don't forget the request header stuff.
                request.Content = new StringContent(requestBody, Encoding.UTF8, Constants.RequestMediaType);
                // Todo We should be alternating between the subscription key. When we detect it's not working.
                request.Headers.Add(Constants.RequestHeaderSubscriptionKey, _cognitiveServiceConfig.SubscriptionKey);
                request.Headers.Add(Constants.RequestHeaderSubscriptionRegion, _cognitiveServiceConfig.SubscriptionRegion);

                using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<ResponseBody>>(responseBody);

                        return result;
                    }
                    else
                    {
                        var message = $"Problem happened during translation. " +
                                        $"Status code: {response.StatusCode}, " +
                                        $"Reason: {response.ReasonPhrase}";

                        var exception = new TranslateException(message);
                        exception.ParseResponseError(response);
                        throw exception;
                    }
                }
            }
        }

        /// <summary>
        /// Translates the content.
        /// </summary>
        /// <param name="content">The content. (Max.: 100 items)</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The translated content
        /// </returns>
        public Task<IList<ResponseBody>> TranslateAsync(RequestContent content, RequestParameter options)
        {
            return TranslateAsync(new[] { content }, options);
        }
    }
}
