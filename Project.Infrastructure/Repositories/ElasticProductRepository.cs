using Bogus;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Clients.Elasticsearch;
using Project.Domain.Entities;

namespace Project.Infrastructure.Repositories;

public class ElasticProductRepository : IProductRepository
{
    private readonly ElasticsearchClient client;

    public ElasticProductRepository(ElasticsearchClient client)
    {
        this.client = client;
    }

    public async Task<string> CreateAsync(Product product, CancellationToken cancellationToken)
    {
        var request = new CreateRequest<Product>
        {
            Index = "products",
            Id = product.Id.ToString(),
            Document = product
        };

        var response = await this.client.CreateAsync(request, cancellationToken);

        return response.Id;
    }
    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        await this.client.UpdateAsync<Product, Product>(new UpdateRequest<Product, Product>("products", product.Id.ToString())
        {
            Doc = product
        }, cancellationToken);
    }
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await this.client.DeleteAsync("products", id, cancellationToken);
    }
    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await this.client.SearchAsync<Product>(new SearchRequest("products")
        {
            Size = 100,
            Query = new MatchAllQuery()
        }, cancellationToken);

        return response.Documents;
    }
    public async Task SeedDataAsync(CancellationToken cancellationToken)
    {
        var faker = new Faker();

        for (int i = 0; i < 100; i++)
        {
            var product = new Product
            {
                Name = faker.Commerce.ProductName(),
                Price = Convert.ToDecimal(faker.Commerce.Price()),
                Stock = faker.Random.Int(1, 20),
                Description = faker.Commerce.ProductDescription()
            };

            await CreateAsync(product, cancellationToken);
        }
    }
}