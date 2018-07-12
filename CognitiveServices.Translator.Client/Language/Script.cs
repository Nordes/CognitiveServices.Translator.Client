using System.Collections.Generic;

namespace CognitiveServices.Translator.Client.Language
{
    public class Script: IScript
    {
        /// <summary>
        /// Code identifying the script.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Display name of the script in the locale requested via Accept-Language header.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display name of the language in the locale native for the language.
        /// </summary>
        public string NativeName { get; set; }

        /// <summary>
        /// Directionality, which is rtl for right-to-left languages or ltr for left-to-right languages.
        /// </summary>
        public TextDirection Dir { get; set; }

        /// <summary>
        /// Gets or sets to scripts.
        /// </summary>
        public IList<IScript> ToScripts { get; set; }
    }
}