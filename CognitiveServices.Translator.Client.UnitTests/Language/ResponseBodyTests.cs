using CognitiveServices.Translator.Client.Language;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CognitiveServices.Translator.Client.UnitTests.Language
{
    [Trait("Category", "Unit")]
    public class ResponseBodyTests
    {
        [Fact]
        public void Ctor_WhenDeserializing_ExpectSuccess()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            var content = File.ReadAllText(Path.Combine(path, "Fixtures/Language_AllScopes.json"));
            JsonConvert.DeserializeObject<ResponseBody>(content);
        }
    }
}
