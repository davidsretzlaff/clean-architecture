using Hostly.Domain.Abstractions;
using MediatR;

namespace Hostly.Application.Abstractions.Messaging;

 public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
