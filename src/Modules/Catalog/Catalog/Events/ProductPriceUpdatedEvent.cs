using Catalog.Products.Models;
using Shared;

namespace Catalog.Events;

public record  ProductPriceUpdatedEvent (Product Product) : IDomainEvent;