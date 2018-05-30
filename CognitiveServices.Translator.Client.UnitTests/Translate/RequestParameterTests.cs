using System;
using CognitiveServices.Translator.Translate;
using Xunit;

namespace CognitiveServices.Translator.Client.UnitTests.Translate
{
    public class RequestParameterTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData()]
        public void ToQueryString_WhenToIsInvalid_ExpectException(params string[] data)
        {
            var rp = new RequestParameter();
            rp.To = data;

            Assert.Throws<Exception>(() => rp.ToQueryString());
        }

        [Theory]
        [InlineData("api-version=3.0&to=fr", "fr")]
        [InlineData("api-version=3.0&to=fr&to=en", "fr", "en")]
        public void ToQueryString_WhenToIsValid_ExpectCorrectQueryString(string expected, params string[] data)
        {
            var rp = new RequestParameter();
            rp.To = data;

            var qs = rp.ToQueryString();

            Assert.Equal(expected, qs);
        }
    }
}
