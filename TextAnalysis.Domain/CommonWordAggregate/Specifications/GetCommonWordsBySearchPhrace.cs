using Ardalis.Specification;
using TextAnalysis.Domain.CommonWordAggregate.Enteties;

public class GetCommonWordsBySearchPhraceSpec : Specification<CommonWord>, ISingleResultSpecification
{
    public GetCommonWordsBySearchPhraceSpec(string searchPhrace)
    {
        Query
          .Where(commonWord => commonWord.Name.Contains(searchPhrace));
    }
}