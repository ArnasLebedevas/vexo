using MediatR;
using Vexo.Application.Common;

namespace Vexo.Application.Interfaces.CQRS;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse> { }