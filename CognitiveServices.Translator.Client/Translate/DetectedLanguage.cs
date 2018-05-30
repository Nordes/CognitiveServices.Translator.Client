namespace CognitiveServices.Translator.Translate
{
    /// <summary>
    /// An object describing the detected language 
    /// </summary>
    public class DetectedLanguage
    {
        /// <summary>
        /// A string representing the code of the detected language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// A float value indicating the confidence in the result. The score is 
        /// between zero and one and a low score indicates a low confidence.
        /// </summary>
        public decimal Score { get; set; }
    }
}
