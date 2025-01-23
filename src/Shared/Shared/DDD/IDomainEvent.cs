using MediatR;

namespace Shared.DDD;

public interface IDomainEvent :INotification
{
    Guid EventId => Guid.NewGuid();
    DateTime TimeStamp => DateTime.UtcNow;
    string EventName => GetType().AssemblyQualifiedName!;
}