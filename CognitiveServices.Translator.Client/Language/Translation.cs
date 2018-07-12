namespace CognitiveServices.Translator.Client.Language
{
    public class Translation: ITranslation
    {
        /// <summary>
        /// Display name of the language in the locale requested via Accept-Language header.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Display name of the language in the locale native for this language.
        /// </summary>
        public string NativeName { get; set; }

        /// <summary>
        /// Directionality, which is rtl for right-to-left languages or ltr for left-to-right languages.
        /// </summary>
        /// <remarks>
        /// Usually also accessible from the CultureInfo object:
        /// Ex.: System.Globalization.CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
        /// </remarks>
        public TextDirection Dir { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <remarks>
        /// Sets if within a dictionary.
        /// </remarks>
        public string Code { get; set; }
    }
}