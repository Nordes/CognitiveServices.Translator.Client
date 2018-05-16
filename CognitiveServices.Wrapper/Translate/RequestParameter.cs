using System;
using System.Text;

namespace CognitiveServices.Wrapper.Translate
{
    public class RequestParameter
    {
        public RequestParameter()
        {
            TextType = TextType.Plain;
        }

        /// <summary>
        /// Specifies the language of the input text. Find which languages are available to 
        /// translate from by looking up supported languages using the translation scope. If 
        /// the from parameter is not specified, automatic language detection is applied 
        /// to determine the source language.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Specifies the language of the output text. The target language must be one 
        /// of the supported languages included in the translation scope. For example, 
        /// use to=de to translate to German.
        /// 
        /// It's possible to translate to multiple languages simultaneously by repeating 
        /// the parameter in the query string. For example, use to=de&to=it to translate 
        /// to German and Italian.
        /// </summary>
        /// <remarks>Required value.</remarks>
        public string[] To { get; set; }

        /// <summary>
        /// Defines whether the text being translated is plain text or HTML text. 
        /// Any HTML needs to be a well-formed, complete element. Possible values are: plain (default) or html.
        /// </summary>
        public TextType TextType { get; set; }

        /// <summary>
        /// A string specifying the category (domain) of the translation. This parameter
        /// is used to get translations from a customized system built with Microsoft Translator Hub. Default value is: general.
        /// </summary>
        public string Category => "general";

        /// <summary>
        /// Specifies how profanities should be treated in translations. Possible values 
        /// are: NoAction (default), Marked or Deleted. To understand ways to treat profanity, 
        /// see Profanity handling.
        /// </summary>
        public ProfanityAction ProfanityAction => ProfanityAction.NoAction;

        /// <summary>
        /// Specifies how profanities should be marked in translations. Possible values are:
        /// Asterisk (default) or Tag. To understand ways to treat profanity, see Profanity handling.
        /// </summary>
        public ProfanityMarker ProfanityMarker => ProfanityMarker.Asterisk;

        /// <summary>
        /// Specifies a fallback language if the language of the input text 
        /// can't be identified. Language auto-detection is applied when the 
        /// from parameter is omitted. If detection fails, the suggestedFrom 
        /// language will be assumed.
        /// </summary>
        public bool IncludeAlignment { get; set; }

        /// <summary>
        /// Specifies whether to include sentence boundaries for the input text and the 
        /// translated text. Possible values are: true or false (default).
        /// </summary>
        public bool IncludeSentenceLength { get; set; }

        /// <summary>
        /// If auto-detection fails, it will be using this parameter.
        /// </summary>
        public string SuggestedFrom { get; set; }

        /// <summary>
        /// Specifies the script of the input text.
        /// </summary>
        public string FromScript { get; set; }

        /// <summary>
        /// Specifies the script of the translated text.
        /// </summary>
        public string ToScript { get; set; }

        private bool Validate()
        {
            // We should compare with the data available from a first api call
            // https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-languages?tabs=curl
            // scope=translation... (3 scopes) and could be in a Singleton during the injection
            if (To == null || To.Length == 0)
            {
                throw new Exception("The parameter <To> is required.");
            }

            return true;
        }

        /// <summary>
        /// To the query string.
        /// </summary>
        /// <returns></returns>
        internal string ToQueryString()
        {
            if (!Validate())
                throw new Exception("Invalid request parameter");

            var qs = new StringBuilder();
            qs.Append($"to={string.Join("&to=", To)}&");
            if (!string.IsNullOrEmpty(From))
                qs.Append($"from={From}&");
            if (TextType != TextType.Plain)
                qs.Append($"textType={TextType.ToString()}&");
            if (!Category.Equals("general", StringComparison.OrdinalIgnoreCase))
                qs.Append($"category={Category}&");
            if (ProfanityAction != ProfanityAction.NoAction)
                qs.Append($"profanityAction={ProfanityAction.ToString()}&");
            if (ProfanityMarker != ProfanityMarker.Asterisk)
                qs.Append($"profanityMarker={ProfanityMarker.ToString()}&");
            if (IncludeAlignment)
                qs.Append("includeAlignment=true&");
            if (IncludeSentenceLength)
                qs.Append("includeSentenceLength=true&");
            if (!string.IsNullOrEmpty(SuggestedFrom))
                qs.Append($"suggestedFrom={SuggestedFrom}&");
            if (!string.IsNullOrEmpty(FromScript))
                qs.Append($"fromScript={FromScript}&");
            if (!string.IsNullOrEmpty(ToScript))
                qs.Append($"toScript={ToScript}&");

            // Remove the last character
            qs.Length = qs.Length - 1;

            // cref: https://docs.microsoft.com/en-us/azure/cognitive-services/translator/quickstarts/csharp
            return $"api-version={Constants.ApiVersion}&{qs.ToString()}";
        }
    }
}
