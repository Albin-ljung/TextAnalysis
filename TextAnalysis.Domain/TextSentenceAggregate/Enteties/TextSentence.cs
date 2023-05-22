using TextAnalysis.Domain.Interfaces;

namespace TextAnalysis.Domain.TextSentenceAggregate.Enteties
{
    public class TextSentence : BaseEntity, IAggregateRoot
    {
        public string Text { get; set; } = string.Empty;

        public TextSentence(string text)
        {
            Text = text;
        }   
    }
}
