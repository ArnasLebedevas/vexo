using MediatR;
using Vexo.Application.Common;

namespace Vexo.Application.Interfaces.CQRS;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse> { }