using System.Collections.Generic;
using CognitiveServices.Translator.Translate;
using Xunit;

namespace CognitiveServices.Translator.Client.UnitTests
{
    public class TranslateClientTests
    {
        [Fact]
        public void Temporary_TranslateResultMappingTest()
        {
            var fromText = "aさん.\r";
            var json = "[{\"translations\":[{\"text\":\"Mr.A.\\r\",\"to\":\"en\",\"alignment\":" +
                "{\"proj\":\"0:0 - 4:4 1:2 - 0:1\"}" +
                "}]}]";

            var resp = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResponseBody>>(json);
            Assert.NotNull(resp);
        }
    }
}
