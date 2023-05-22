using Microsoft.AspNetCore.Mvc;
using TextAnalysis.Domain.Interfaces;
using TextAnalysis.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CommonWordsController : ControllerBase
{
    private readonly ICommonWordService _commonWordService;

    public CommonWordsController(ICommonWordService commonWordService)
    {
        _commonWordService = commonWordService;
    }

    [HttpGet]
    public async Task<ActionResult<CommonWordsReponseDTO>> Get()
    {
        var commonWords = await _commonWordService.GetAllCommonWords();
        return Ok(new SentenceResponseDTO
        {
            CommonWords = commonWords.Select(word => new CommonWordDTO(word.Name, word.Frequency)).OrderByDescending(word => word.frequency).ToList()
        });
    }
}