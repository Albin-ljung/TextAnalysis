using Ardalis.Specification;

namespace TextAnalysis.Domain.Interfaces;
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}

