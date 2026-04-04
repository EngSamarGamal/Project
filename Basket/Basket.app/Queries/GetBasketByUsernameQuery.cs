using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Queries
{
    public class GetBasketByUsernameQuery : IRequest<ShoppingCart>
    {
        public string Username { get; set; }

        public GetBasketByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
