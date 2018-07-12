using System;
using System.Globalization;

namespace CognitiveServices.Translator.Client.Language
{
    public class RequestHeader
    {
        /// <summary>
        /// Gets or sets the accept language.
        /// </summary>
        /// <example>
        /// The language to use for user interface strings. Some of the fields in the response 
        /// are names of languages or names of regions. Use this parameter to define the language 
        /// in which these names are returned. The language is specified by providing a well-formed 
        /// BCP 47 language tag. For instance, use the value fr to request names in French or use 
        /// the value zh-Hant to request names in Chinese Traditional.
        /// </example>
        /// <remarks>
        /// Names are provided in the English language when a target language is not specified 
        /// or when localization is not available.
        ///</remarks>
        public CultureInfo AcceptLanguage { get; set; } = new CultureInfo("en");

        /// <summary>
        /// Gets or sets the client trace identifier. This is client-generated GUID to uniquely 
        /// identify the request.
        /// </summary>
        /// <remarks>
        /// Optional
        /// </remarks>
        public Guid? ClientTraceId { get; set; } = null;
    }
}
