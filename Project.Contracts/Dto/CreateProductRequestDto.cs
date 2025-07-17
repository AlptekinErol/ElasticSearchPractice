namespace Project.Contracts.Dto;

public record CreateProductRequestDto(string Name, decimal Price, int Stock, string Description);
