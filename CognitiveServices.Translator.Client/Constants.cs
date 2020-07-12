namespace CognitiveServices.Translator
{
    internal static class Constants
    {
        public const string TranslatorApiBasePath = "https://api.cognitive.microsofttranslator.com/";
        public const string RequestMediaType = "application/json";
        public const string RequestHeaderSubscriptionKey = "Ocp-Apim-Subscription-Key";
        public const string RequestHeaderSubscriptionRegion = "Ocp-Apim-Subscription-Region";

        /// <summary>
        /// Gets the API version.
        /// </summary>
        /// <remarks>Required value.</remarks>
        internal const string ApiVersion = "3.0";
    }
}
