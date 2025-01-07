using Catalog.Products.Models;
using Shared;

namespace Catalog.Events;

public record ProductCreatedEvent(Product Product) : IDomainEvent;