using MediatR;
using Vexo.Application.Common;

namespace Vexo.Application.Interfaces.CQRS;

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }