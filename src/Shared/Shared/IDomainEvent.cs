using MediatR;

namespace Shared;

public interface IDomainEvent :INotification
{
    Guid EventId => Guid.NewGuid();
    DateTime TimeStamp => DateTime.UtcNow;
    string EventName => GetType().AssemblyQualifiedName!;
}