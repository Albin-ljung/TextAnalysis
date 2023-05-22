using TextAnalysis.Domain.Interfaces;

namespace TextAnalysis.Domain.CommonWordAggregate.Enteties
{
    public class CommonWord : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
    }
}
