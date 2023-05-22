using TextAnalysis.Domain.Interfaces;
using TextAnalysis.Domain.TextSentenceAggregate.Enteties;
using Microsoft.Extensions.Logging;


namespace TextAnalysis.Application.Services;
public class SentenceService : ISentenceService
{
    private readonly IRepository<TextSentence> _sentenceRepository;
    private readonly ILogger<SentenceService> _logger;

    public SentenceService(
        IRepository<TextSentence> sentenceRepository,
        ILogger<SentenceService> logger)
    {
        _sentenceRepository = sentenceRepository;
        _logger = logger;
    }

    public async Task<TextSentence> CreateSentence(TextSentence sentence)
    {
        try
        {
            return await _sentenceRepository.AddAsync(sentence);
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while creating the sentence. Message: {e.Message}. Stacktrace: {e.StackTrace}.");
            throw;
        }
    }

}
