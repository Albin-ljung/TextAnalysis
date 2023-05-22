using TextAnalysis.Domain.TextSentenceAggregate.Enteties;

namespace TextAnalysis.Domain.Interfaces;
public interface ISentenceService
{
    Task<TextSentence> CreateSentence(TextSentence sentence);
}

