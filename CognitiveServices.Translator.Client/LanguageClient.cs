﻿using CognitiveServices.Translator.Client.Extension;
using CognitiveServices.Translator.Client.Language;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CognitiveServices.Translator.Client
{
    /// <summary>
    /// Get the languages supported within the system.
    /// </summary>
    /// <seealso cref="ILanguageClient" />
    /// <remarks>
    /// The API's accessed within this client does not require the API Key. 
    /// </remarks>
    public class LanguageClient : ILanguageClient
    {
        private const string UriExtensionPath = "languages";
        private readonly HttpClient _httpClient;
        private ResponseBody _cachedFullScopes;

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslateClient" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="cognitiveServiceConfig">The cognitive service configuration.</param>
        public LanguageClient()
        {
            // In Core 2.1, we can use what is described in: https://docs.microsoft.com/en-gb/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.1
            // Otherwise, maybe use RestSharp?
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Constants.TranslatorApiBasePath)
            };
        }

        /// <summary>
        /// Gets the specified scope.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        /// <remarks>
        /// Default scope is ALL scope.
        /// </remarks>
        public Task<ResponseBody> GetAsync(RequestHeader settings)
        {
            return GetAsync(settings, Scope.All);
        }

        /// <summary>
        /// Gets the specified scope.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="scopes">The scopes.</param>
        /// <returns></returns>
        public async Task<ResponseBody> GetAsync(RequestHeader settings, Scope scopes)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            var scopeFlags = string.Join(",", scopes.GetFlags());
            var qs = $"api-version={Constants.ApiVersion}&scope={scopeFlags.Replace(",All", "")}";

            // Not the best, but for now it will do.
            if (_cachedFullScopes != null)
                return _cachedFullScopes; // TODO use a memory cache, or other cache.

            using (var request = new HttpRequestMessage(HttpMethod.Get, $"{UriExtensionPath}?{qs}"))
            {
                request.Headers.AcceptLanguage.TryParseAdd(settings.AcceptLanguage.Name);
                if (settings.ClientTraceId.HasValue)
                    request.Headers.Add("X-ClientTraceId", settings.ClientTraceId.Value.ToString());

                using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        response.Headers.TryGetValues("ETag", out var etag);
                        response.Headers.TryGetValues("X-RequestId", out var xRequestId);

                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ResponseBody>(responseBody);

                        if (scopes == Scope.All)
                            _cachedFullScopes = result;

                        return result;
                    }
                    else
                    {
                        string errorBody = $"Problem happened while contacting the Language API. " +
                            $"Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}";
                        {
                            var message = $"Problem happened during translation. " +
                                            $"Status code: {response.StatusCode}, " +
                                            $"Reason: {response.ReasonPhrase}";

                            var exception = new LanguageException(message);
                            exception.ParseResponseError(response);
                            throw exception;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the specified scope.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        /// <remarks>
        /// Default scope is ALL scope.
        /// </remarks>
        public ResponseBody Get(RequestHeader settings)
        {
            return GetAsync(settings, Scope.All).Result;
        }

        /// <summary>
        /// Gets the specified scope.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="scopes">The scopes.</param>
        /// <returns></returns>
        public ResponseBody Get(RequestHeader settings, Scope scopes)
        {
            return GetAsync(settings, scopes).Result;
        }
    }
}
