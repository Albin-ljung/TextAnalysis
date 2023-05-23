using Microsoft.AspNetCore.Mvc;
using TextAnalysis.Domain.Interfaces;
using TextAnalysis.Domain.TextSentenceAggregate.Enteties;

namespace TextAnalysis.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SentenceController : ControllerBase
{
    private readonly ISentenceService _sentenceService;
    private readonly ICommonWordService _commonWordService;
    private readonly CreateSentenceValidator _validator;

    public SentenceController(
        ISentenceService sentenceService,
        ICommonWordService commonWordService,
        CreateSentenceValidator validator)
    {
        _sentenceService = sentenceService;
        _commonWordService = commonWordService;
        _validator = validator;
    }

    [HttpPost]
    public async Task<ActionResult<SentenceResponseDTO>> Create([FromBody] SentenceRequestDTO request)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var newSentence = new TextSentence(request.Sentence);
        var createdSentence = await _sentenceService.CreateSentence(newSentence);
        if (createdSentence == null) return BadRequest();

        var commonWords = _commonWordService.CalcCommonWordsFromSentence(createdSentence, 10);
        _commonWordService.CreateOrUpdateWordWithFrequency(createdSentence);

        return Ok(new SentenceResponseDTO
        {
            CommonWords = commonWords.Select(word => new CommonWordDTO(word.Name, word.Frequency)).ToList()
        });
    }
}

