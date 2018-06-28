using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CognitiveServices.Translator;
using CognitiveServices.Translator.Translate;
using CognitiveServices.Translator.Client.WebSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Vue2Spa.Controllers
{
    [Route("api/[controller]")]
    public class TranslateController : Controller
    {
        private readonly ILogger<TranslateController> _logger;
        private readonly ITranslateClient _translateClient;

        public TranslateController(ILogger<TranslateController> logger, ITranslateClient translateClient)
        {
            _logger = logger;
            _translateClient = translateClient;
        }

        [HttpPut("withDI")]
        public async Task<IList<ResponseBody>> WithDependencyInjection([FromBody] TranslateRequest translate)
        {
            return await _translateClient.TranslateAsync(translate.RequestContents, translate.Options);
        }

        [HttpPut()]
        public async Task<IList<ResponseBody>> Index([FromBody] TranslateRequest translate)
        {
            try
            {
                // Create a call with the configuration from a client.
                var translateClient = new TranslateClient(translate.CognitiveServicesConfig);
                return await translateClient.TranslateAsync(translate.RequestContents, translate.Options);
            }
            catch (Exception e)
            {
                _logger.LogError(default(EventId), e, "Error!!!!");
                throw e;
            }
        }
    }
}
