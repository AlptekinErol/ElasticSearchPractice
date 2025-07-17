using Project.Contracts.Dto;

namespace Project.Application.Interfaces;

public interface IProductService
{
    Task<string> CreateAsync(CreateProductRequestDto request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateProductRequestDto request, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<ProductResponseDto>> GetAllAsync(CancellationToken cancellationToken);
    Task SeedDataAsync(CancellationToken cancellationToken);
}
