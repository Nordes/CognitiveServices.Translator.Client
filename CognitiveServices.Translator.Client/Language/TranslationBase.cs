namespace CognitiveServices.Translator.Client.Language
{
    public class TranslationBase
    {
        /// <summary>
        /// Display name of the language in the locale requested via Accept-Language header.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Display name of the language in the locale native for this language.
        /// </summary>
        string NativeName { get; set; }

        /// <summary>
        /// Directionality, which is rtl for right-to-left languages or ltr for left-to-right languages.
        /// </summary>
        /// <remarks>
        /// Usually also accessible from the CultureInfo object:
        /// Ex.: System.Globalization.CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
        /// </remarks>
        TextDirection Dir { get; set; }
    }
}
