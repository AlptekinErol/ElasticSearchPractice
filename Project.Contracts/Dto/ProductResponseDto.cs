namespace Project.Contracts.Dto;

public record ProductResponseDto(Guid Id, string Name, decimal Price, int Stock, string Description);