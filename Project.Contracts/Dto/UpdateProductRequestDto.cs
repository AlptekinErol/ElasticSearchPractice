namespace Project.Contracts.Dto;

public record UpdateProductRequestDto(Guid Id, string Name, decimal Price, int Stock, string Description);