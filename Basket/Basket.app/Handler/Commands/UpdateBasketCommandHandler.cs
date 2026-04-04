using AutoMapper;
using Basket.Application.Commands;
using Basket.Core.Entities;
using Basket.Infrastructure.Repositories;
using MediatR;

namespace Basket.Application.Handler.Commands
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, ShoppingCart>
    {
        private readonly BasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public UpdateBasketCommandHandler(BasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<ShoppingCart> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = _mapper.Map<ShoppingCart>(request);
            return await _basketRepository.UpdateBasket(basket);
        }
    }
}
