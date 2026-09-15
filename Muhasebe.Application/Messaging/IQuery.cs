
using MediatR;

namespace Muhasebe.Application.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }
}
