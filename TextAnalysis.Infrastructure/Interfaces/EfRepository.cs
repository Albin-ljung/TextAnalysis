using Ardalis.Specification.EntityFrameworkCore;
using TextAnalysis.Domain.Interfaces;
using TextAnalysis.Infrastructure.Data;

namespace TextAnalysis.Infrastructure.Interfaces;
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(TextAnalysisDBContext dbContext) : base(dbContext) { }
}

