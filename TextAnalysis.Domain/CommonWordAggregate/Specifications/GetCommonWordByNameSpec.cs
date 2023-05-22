using Ardalis.Specification;
using TextAnalysis.Domain.CommonWordAggregate.Enteties;
public class GetCommonWordsByNameSpec : Specification<CommonWord>, ISingleResultSpecification
{
    public GetCommonWordsByNameSpec(string name)
    {
        Query
          .Where(commonWord => commonWord.Name.ToLower() == name.ToLower());
    }
}