using Catalog.Products.Models;
using Shared;
using Shared.DDD;

namespace Catalog.Events;

public record  ProductPriceUpdatedEvent (Product Product) : IDomainEvent;