
namespace TextAnalysis.Web.Controllers
{
    public class SentenceRequestDTO
    {
        public string Sentence { get; set; } = string.Empty;

        public SentenceRequestDTO(string sentence)
        {
            Sentence = sentence;
        }
    }
}
