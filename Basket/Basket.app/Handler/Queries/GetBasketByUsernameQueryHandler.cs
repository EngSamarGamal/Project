using Basket.Application.Queries;
using Basket.Core.Entities;
using Basket.Infrastructure.Repositories;
using MediatR;

namespace Basket.Application.Handler.Queries
{
    public class GetBasketByUsernameQueryHandler : IRequestHandler<GetBasketByUsernameQuery, ShoppingCart>
    {
        private readonly BasketRepository _basketRepository;

        public GetBasketByUsernameQueryHandler(BasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<ShoppingCart> Handle(GetBasketByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await _basketRepository.GetBasket(request.Username);
        }
    }
}
