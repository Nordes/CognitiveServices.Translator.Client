using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Vue2Spa.Controllers
{
    [Route("api/[controller]")]
    public class TranslateController : Controller
    {
        public TranslateController()
        {
            // Whatever..
        }

        [HttpGet("[action]")]
        public object Translate() {
            return null;
        }
    }
}
