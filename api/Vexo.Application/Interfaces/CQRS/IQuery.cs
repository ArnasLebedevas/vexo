using MediatR;
using Vexo.Application.Common;

namespace Vexo.Application.Interfaces.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }