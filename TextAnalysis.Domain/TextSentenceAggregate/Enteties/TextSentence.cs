using TextAnalysis.Domain.Interfaces;

namespace TextAnalysis.Domain.TextSentenceAggregate.Enteties;
public class TextSentence : BaseEntity, IAggregateRoot
{
    public string Sentence { get; set; } = string.Empty;

    public TextSentence(string sentence)
    {
        Sentence = sentence;
    }
}

