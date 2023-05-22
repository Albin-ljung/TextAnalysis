using Microsoft.Extensions.Logging;
using TextAnalysis.Domain.CommonWordAggregate.Enteties;
using TextAnalysis.Domain.Interfaces;
using TextAnalysis.Domain.TextSentenceAggregate.Enteties;

namespace TextAnalysis.Application.Services;
public class CommonWordService : ICommonWordService
{
    private readonly IRepository<CommonWord> _commonWordRepository;
    private readonly ILogger<CommonWordService> _logger;

    public CommonWordService(
        IRepository<CommonWord> commonWordRepository,
        ILogger<CommonWordService> logger)
    {
        _commonWordRepository = commonWordRepository;
        _logger = logger;
    }

    public List<CommonWord> CalcCommonWordsFromSentence(TextSentence textSentence)
    {
        string[] words = textSentence.Sentence.ToLower().Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
        List<CommonWord> commonWords = new List<CommonWord>();

        foreach (string word in words)
        {
            var wordExist = commonWords.Find(commonWord => string.Equals(commonWord.Name, word, StringComparison.OrdinalIgnoreCase));
            if (wordExist != null)
                wordExist.AddFrequency();
            else
                commonWords.Add(new CommonWord(word));
        }

        return commonWords;
    }

    public async Task<List<CommonWord>> GetAllCommonWords()
    {
        try
        {
            return await _commonWordRepository.ListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while getting all the Common words. Message: {e.Message}. Stacktrace: {e.StackTrace}.");
            throw;
        }
    }

    public async void CreateOrUpdateWordWithFrequency(TextSentence textSentence)
    {
        string[] words = textSentence.Sentence.ToLower().Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            var commonWordByNameSpec = new GetCommonWordsByNameSpec(word);
            var commonWordExist = await _commonWordRepository.FirstOrDefaultAsync(commonWordByNameSpec);
            if (commonWordExist != null)
            {
                commonWordExist.AddFrequency();
                try
                {
                    await _commonWordRepository.UpdateAsync(commonWordExist);
                }
                catch (Exception e)
                {
                    _logger.LogError($"An error occurred while updating the Common word. Message: {e.Message}. Stacktrace: {e.StackTrace}.");
                    throw;
                }
            }
            else
            {
                try
                {
                    await _commonWordRepository.AddAsync(new CommonWord(word));
                }
                catch (Exception e)
                {
                    _logger.LogError($"An error occurred while trying to add common word. Message: {e.Message}. Stacktrace: {e.StackTrace}.");
                    throw;
                }
            }
        }
    }

    public async Task<List<CommonWord>> GetCommonWordsBySearchPhrase(string searchPhrace)
    {
        var commonWordsBySearchPhraceSpec = new GetCommonWordsBySearchPhraseSpec(searchPhrace);
        try
        {
           return await _commonWordRepository.ListAsync(commonWordsBySearchPhraceSpec);
        }
        catch(Exception e)
        {
            _logger.LogError($"An error occurred while trying to get common word by search phrase. Message: {e.Message}. Stacktrace: {e.StackTrace}.");
            throw;
        }
    }
}
