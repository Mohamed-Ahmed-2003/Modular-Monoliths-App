using Catalog.Products.Features.Handler.CreateProduct;

namespace Catalog.Products.Features.CreateProduct.Endpoint;

// Request 
public  record CreateProductRequest(ProductDto Product);
// Response
public  record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", HandleCreateProduct)
            .WithName("CreateProduct") // Gives the endpoint a name for better route management
            .Produces<CreateProductResponse>(StatusCodes.Status201Created) // Indicates the expected response type
            .Produces(StatusCodes.Status400BadRequest);
    }

    private async Task<IResult> HandleCreateProduct(CreateProductRequest request, ISender mediator)
    {
        var command = request.Adapt<CreateProductCommand>();

        var result = await mediator.Send(command);
        var response = result.Adapt<CreateProductResponse>();

        return Results.Created($"/products/{response.Id}", response);
    }
}