using CognitiveServices.Wrapper.Translator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CognitiveServices.Wrapper
{
    public interface ITranslatorClient
    {
        Task<IList<ResponseBody>> TranslateAsync(IEnumerable<RequestContent> content, RequestParameter options);
        Task<IList<ResponseBody>> TranslateAsync(RequestContent content, RequestParameter options);

        IList<ResponseBody> Translate(IEnumerable<RequestContent> content, RequestParameter options);
        IList<ResponseBody> Translate(RequestContent content, RequestParameter options);
    }
}
