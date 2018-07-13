using System.Collections.Generic;

namespace CognitiveServices.Translator.Client.Language
{
    public class Dictionary
    {
        /// <summary>
        /// Display name of the source language in the locale requested via Accept-Language header.
        /// </summary>
        public string Name { get; set; }

        public string NativeName { get; set; }

        public TextDirection Dir { get; set; }

        public List<Translation> Translations { get; set; }
    }
}