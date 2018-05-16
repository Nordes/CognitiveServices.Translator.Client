namespace CognitiveServices.Wrapper.Translate
{
    public class Translations
    {
        /// <summary>
        /// A string representing the language code of the target language.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// A string giving the translated text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// An object giving the translated text in the script specified by the 
        /// toScript parameter.
        /// </summary>
        /// <remarks>
        /// The transliteration object is not included if transliteration does 
        /// not take place.
        /// </remarks>
        public Transliteration Transliteration { get; set; }

        /// <summary>
        /// Maps input text to translated text
        /// </summary>
        /// <remarks>
        /// The aligment information is only provided when the request parameter 
        /// includeAlignment is <c>true</c>
        /// </remarks>
        public Alignment Alignment { get; set; }

        /// <summary>
        /// Sentence boundaries in the input and output texts.
        /// </summary>
        /// <remarks>Sentence boundaries are only included when the request parameter 
        /// includeSentenceLength is true.</remarks>
        public SentLen SentLen { get; set; }

        /// <summary>
        /// Gives the input text in the default script of the source language.
        /// </summary>
        /// <remarks>
        /// sourceText property is present only when the input is expressed in 
        /// a script that's not the usual script for the language. 
        /// </remarks>
        /// <example>
        /// For example, if the input were Arabic written in Latin script, then sourceText.
        /// Text would be the same Arabic text converted into Arab script.
        /// </example>
        public dynamic SourceText { get; set; }
    }
}
