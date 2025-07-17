using Microsoft.AspNetCore.Mvc;
using Project.Application.Interfaces;
using Project.Contracts.Dto;

namespace Project.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService productService;

    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequestDto request, CancellationToken cancellationToken)
    {
        var id = await this.productService.CreateAsync(request, cancellationToken);
        return Ok(new { Id = id });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductRequestDto request, CancellationToken cancellationToken)
    {
        await this.productService.UpdateAsync(request, cancellationToken);
        return Ok(new { Message = "Product updated" });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await this.productService.DeleteAsync(id, cancellationToken);
        return Ok(new { Message = "Product deleted" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var products = await this.productService.GetAllAsync(cancellationToken);
        return Ok(products);
    }
}