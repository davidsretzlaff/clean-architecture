using Hostly.Domain.Abstractions;
using MediatR;

namespace Hostly.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}