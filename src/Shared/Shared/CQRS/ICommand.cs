using MediatR;

namespace Shared.CQRS;

public interface ICommand : IRequest<Unit>
{
}
public interface ICommand<out T> : IRequest<T>
{
}