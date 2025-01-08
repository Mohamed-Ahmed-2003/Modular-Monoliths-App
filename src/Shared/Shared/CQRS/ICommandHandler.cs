using MediatR;

namespace Shared.CQRS;

public interface ICommandHandler<in TCommand , TRes> : IRequestHandler<TCommand, TRes>
    where TCommand : ICommand<TRes>
    where TRes: notnull
{
    
}