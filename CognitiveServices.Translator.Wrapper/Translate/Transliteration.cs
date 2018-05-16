namespace CognitiveServices.Translator.Translate
{
    public class Transliteration
    {
        /// <summary>
        /// A string specifying the target script.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// A string giving the translated text in the target script.
        /// </summary>
        public string Text { get; set; }
    }
}
