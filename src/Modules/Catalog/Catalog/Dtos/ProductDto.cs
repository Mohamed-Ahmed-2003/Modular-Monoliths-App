namespace Catalog.Dtos;

public record ProductDto(
    Guid Id,
    string Name,
    string? Description,
    string? ImageUrl,
    List<string>? Category,
    decimal Price
);