using System.Collections.Generic;
using System.Threading.Tasks;
using CognitiveServices.Translator.Translate;

namespace CognitiveServices.Translator
{
    public interface ITranslateClient
    {
        Task<IList<ResponseBody>> TranslateAsync(IEnumerable<RequestContent> content, RequestParameter options);
        Task<IList<ResponseBody>> TranslateAsync(RequestContent content, RequestParameter options);

        IList<ResponseBody> Translate(IEnumerable<RequestContent> content, RequestParameter options);
        IList<ResponseBody> Translate(RequestContent content, RequestParameter options);
    }
}
