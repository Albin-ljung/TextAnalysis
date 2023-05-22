using Ardalis.HttpClientTestExtensions;
using Xunit;

namespace TextAnalysis.FunctionalTest.Controllers
{
    public class CommonWordsController : IClassFixture<WebApplicationTestFactory<Program>>
    {
        private readonly HttpClient _client;

        public CommonWordsController(WebApplicationTestFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCommonWords()
        {
            var result = await _client.GetAndDeserializeAsync<CommonWordsReponseDTO>("/commonwords");
            Assert.NotNull(result);
        }
    }
}
