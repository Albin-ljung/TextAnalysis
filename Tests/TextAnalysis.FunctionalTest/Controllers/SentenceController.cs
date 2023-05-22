using Newtonsoft.Json;
using System.Text;
using TextAnalysis.Web.Controllers;
using Ardalis.HttpClientTestExtensions;
using Xunit;

namespace TextAnalysis.FunctionalTest.Controllers
{
    [Collection("Sequential")]
    public class SentenceController : IClassFixture<WebApplicationTestFactory<Program>>
    {
        private readonly HttpClient _client;

        public SentenceController(WebApplicationTestFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateSentence()
        {
            string sentence = "Detta är en ny mening som är ganska kort";
            var result = await _client.PostAndDeserializeAsync<SentenceResponseDTO>("/sentence", new StringContent(JsonConvert.SerializeObject(new SentenceRequestDTO(sentence)), Encoding.UTF8, "application/json"));
            Assert.NotNull(result);
        }
    }
}
