using TextAnalysis.Domain.CommonWordAggregate.Enteties;
using TextAnalysis.Domain.TextSentenceAggregate.Enteties;

namespace TextAnalysis.Domain.Interfaces;
public interface ICommonWordService
{
    List<CommonWord> CalcCommonWordsFromSentence(TextSentence sentence, int count);
    Task<List<CommonWord>> GetAllCommonWords();
    void CreateOrUpdateWordWithFrequency(TextSentence commonWord);
    Task<List<CommonWord>> GetCommonWordsBySearchPhrase(string searchPhrace);
}

