
using MediatR;

namespace Muhasebe.Application.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
