using System.Collections.Generic;
using System.Globalization;

namespace CognitiveServices.Translator.Client.Language
{
    public class ResponseBody
    {
        /// <summary>
        /// The value of the translation property is a dictionary of (key, value) pairs. 
        /// Each key is a BCP 47 language tag. A key identifies a language for which text 
        /// can be translated to or translated from. The value associated with the key is 
        /// a JSON object with properties that describe the language
        /// </summary>
        public IDictionary<CultureInfo, ITranslation> Translation { get; set; }

        /// <summary>
        /// The value of the transliteration property is a dictionary of (key, value) pairs. Each key 
        /// is a BCP 47 language tag. A key identifies a language for which text can be converted from 
        /// one script to another script. The value associated with the key is a JSON object with 
        /// properties that describe the language and its supported scripts
        /// </summary>
        public IDictionary<CultureInfo, Transliteration> Transliteration { get; set; }

        /// <summary>
        /// The value of the dictionary property is a dictionary of (key, value) pairs. Each key is a 
        /// BCP 47 language tag. The key identifies a language for which alternative translations and 
        /// back-translations are available. The value is a JSON object that describes the source 
        /// language and the target languages with available translations.
        /// </summary>
        public IDictionary<CultureInfo, Dictionary> Dictionary { get; set; }
    }
}
