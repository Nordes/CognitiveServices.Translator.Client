namespace CognitiveServices.Translator.Configuration
{
    public class CognitiveServicesConfig
    {
        internal const string SectionName = "CognitiveServices";
        public string Name { get; set; }
        public string SubscriptionKey { get; set; }
        public string SubscriptionKeyAlternate { get; set; }
        public string SubscriptionRegion { get; set; }
    }
}
