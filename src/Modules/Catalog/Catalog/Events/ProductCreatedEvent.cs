using Catalog.Products.Models;
using Shared;
using Shared.DDD;

namespace Catalog.Events;

public record ProductCreatedEvent(Product Product) : IDomainEvent;