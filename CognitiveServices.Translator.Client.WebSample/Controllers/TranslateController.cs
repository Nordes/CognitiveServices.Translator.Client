using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CognitiveServices.Translator;
using CognitiveServices.Translator.Translate;
using CognitiveServices.Translator.Client.WebSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace Vue2Spa.Controllers
{
    [Route("api/[controller]")]
    public class TranslateController : Controller
    {
        public TranslateController()
        {
            // In case of injection... we could then use a scoped OR a different way of using pre-configured
            // translator configuration.
        }

        //[HttpPut("[action]")]
        //public async Task<IList<ResponseBody>> Translate([Required] Translate translate)
        [HttpPut()]
        public async Task<IList<ResponseBody>> Index([FromBody] Translate translate)
        {
            var translateClient = new TranslateClient(translate.CognitiveServicesConfig);

            return await translateClient.TranslateAsync(translate.RequestContents, translate.Options);
        }
    }
}
