using System.Collections.Generic;

namespace CognitiveServices.Translator.Client.Language
{
    public class Transliteration
    {
        /// <summary>
        /// Display name of the language in the locale requested via Accept-Language header.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display name of the language in the locale native for this language.
        /// </summary>
        public string NativeName { get; set; }

        /// <summary>
        /// List of scripts to convert from. Each element of the scripts list has properties.
        /// </summary>
        public List<Script> Scripts { get; set; }
    }
}