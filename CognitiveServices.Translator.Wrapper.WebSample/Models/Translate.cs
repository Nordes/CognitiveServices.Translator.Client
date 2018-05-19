using CognitiveServices.Translator.Configuration;
using CognitiveServices.Translator.Translate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CognitiveServices.Translator.Wrapper.WebSample.Models
{
    public class Translate
    {
        [Required]
        public CognitiveServicesConfig CognitiveServicesConfig { get; set; }

        [Required]
        public IList<RequestContent> RequestContents { get; set; }

        [Required]
        public RequestParameter Options { get; set; }
    }
}
