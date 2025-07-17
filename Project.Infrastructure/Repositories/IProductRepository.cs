using Project.Domain.Entities;

namespace Project.Infrastructure.Repositories;

public interface IProductRepository
{
    Task<string> CreateAsync(Product product, CancellationToken cancellationToken);
    Task UpdateAsync(Product product, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task SeedDataAsync(CancellationToken cancellationToken);
}
