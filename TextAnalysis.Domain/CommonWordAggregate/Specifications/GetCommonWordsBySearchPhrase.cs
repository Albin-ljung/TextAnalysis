using Ardalis.Specification;
using TextAnalysis.Domain.CommonWordAggregate.Enteties;

public class GetCommonWordsBySearchPhraseSpec : Specification<CommonWord>, ISingleResultSpecification
{
    public GetCommonWordsBySearchPhraseSpec(string searchPhrace)
    {
        Query
          .Where(commonWord => commonWord.Name.Contains(searchPhrace));
    }
}