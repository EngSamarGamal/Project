using MediatR;

namespace Basket.Application.Commands
{
    public class DeleteBasketCommand : IRequest<bool>
    {
        public string Username { get; set; }

        public DeleteBasketCommand(string username)
        {
            Username = username;
        }
    }
}
