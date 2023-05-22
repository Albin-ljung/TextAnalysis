using TextAnalysis.Domain.Interfaces;

namespace TextAnalysis.Domain.CommonWordAggregate.Enteties;
public class CommonWord : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public int Frequency { get; set; } = 1;

    public CommonWord(string name)
    {
        Name = name;
    }

    public void AddFrequency()
    {
        Frequency++;
    }
}

