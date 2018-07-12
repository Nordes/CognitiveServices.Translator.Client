namespace CognitiveServices.Translator.Client.Language
{
    public interface IScript
    {
        /// <summary>
        /// Code identifying the script.
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Display name of the script in the locale requested via Accept-Language header.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Display name of the language in the locale native for the language.
        /// </summary>
        string NativeName { get; set; }

        /// <summary>
        /// Directionality, which is rtl for right-to-left languages or ltr for left-to-right languages.
        /// </summary>
        TextDirection Dir { get; set; }
    }
}