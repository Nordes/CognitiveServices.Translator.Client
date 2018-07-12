using CognitiveServices.Translator.Client.Language;
using System.Threading.Tasks;

namespace CognitiveServices.Translator.Client
{
    public interface ILanguageClient
    {
        Task<ResponseBody> GetAsync(RequestHeader settings);
        Task<ResponseBody> GetAsync(RequestHeader settings, Scope scopes);

        ResponseBody Get(RequestHeader settings);
        ResponseBody Get(RequestHeader settings, Scope scopes);
    }
}
