using CognitiveServices.Translator.Client.Language;
using System;
using Xunit;

namespace CognitiveServices.Translator.Client.IntegrationTests
{
    [Trait("Category", "Integration")]
    public class LanguageClientTests
    {
        [Fact]
        public void Ctor_WhenCreating_ExpectSuccess()
        {
            var client = new LanguageClient();
        }

        [Fact]
        public void Get_WhenRequestHeaderNull_ExpectArgumentNullException()
        {
            var client = new LanguageClient();
            var exception = Assert.Throws<ArgumentNullException>(() => client.Get(null));

            Assert.Equal("settings", exception.ParamName);
        }

        [Theory]
        [InlineData(Scope.All)]
        public void Get_WhenScopeSpecified_ExpectData(Scope scopes)
        {
            var client = new LanguageClient();
            var data = client.Get(new RequestHeader(), scopes);

            Assert.NotNull(data);
            Assert.NotEmpty(data.Translation);
            Assert.NotEmpty(data.Dictionary);
            Assert.NotEmpty(data.Transliteration);
        }
    }
}
