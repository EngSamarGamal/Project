using Basket.Application.Commands;
using Basket.Infrastructure.Repositories;
using MediatR;

namespace Basket.Application.Handler.Commands
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, bool>
    {
        private readonly BasketRepository _basketRepository;

        public DeleteBasketCommandHandler(BasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            return await _basketRepository.DeleteBasket(request.Username);
        }
    }
}
