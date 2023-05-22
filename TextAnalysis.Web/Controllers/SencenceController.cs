using Microsoft.AspNetCore.Mvc;
using TextAnalysis.Domain.Interfaces;
using TextAnalysis.Domain.TextSentenceAggregate.Enteties;

namespace TextAnalysis.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SencenceController : ControllerBase
    {
        private readonly ISentenceService _sentenceService;

        public SencenceController(ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;
        }

        [HttpPost]
        public ActionResult<TextSentence> Create(string sentence)
        {
            var newSentence = new TextSentence(sentence);
            var createdSentence = _sentenceService.CreateSentence(newSentence);
            return Ok(createdSentence);
        }
    }
}
