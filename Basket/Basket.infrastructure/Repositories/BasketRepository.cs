using Basket.Core.Entities;
using Basket.Infrastructure.Data.Contexts;
using System.Text.Json;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository
    {
        private readonly BasketContext _context;

        public BasketRepository(BasketContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> GetBasket(string username)
        {
            var data = await _context.Database.StringGetAsync(username);
            if (data.IsNullOrEmpty)
                return new ShoppingCart(username);

            return JsonSerializer.Deserialize<ShoppingCart>(data);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _context.Database.StringSetAsync(
                basket.Username,
                JsonSerializer.Serialize(basket),
                TimeSpan.FromDays(14));

            return await GetBasket(basket.Username);
        }

        public async Task<bool> DeleteBasket(string username)
        {
            return await _context.Database.KeyDeleteAsync(username);
        }
    }
}
