using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands
{
    public class UpdateBasketCommand : IRequest<ShoppingCart>
    {
        public string Username { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new();
    }
}
