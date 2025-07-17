using Project.Application.Interfaces;
using Project.Contracts.Dto;
using Project.Domain.Entities;
using Project.Infrastructure.Repositories;

namespace Project.Application.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;
    public ProductService(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<string> CreateAsync(CreateProductRequestDto request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            Description = request.Description
        };

        return await this.productRepository.CreateAsync(product, cancellationToken);
    }

    public async Task UpdateAsync(UpdateProductRequestDto request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            Description = request.Description
        };

        await this.productRepository.UpdateAsync(product, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken) => this.productRepository.DeleteAsync(id, cancellationToken);

    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await this.productRepository.GetAllAsync(cancellationToken);

        return products.Select(p => new ProductResponseDto(p.Id, p.Name, p.Price, p.Stock, p.Description));
    }

    public Task SeedDataAsync(CancellationToken cancellationToken) => this.productRepository.SeedDataAsync(cancellationToken);
}
