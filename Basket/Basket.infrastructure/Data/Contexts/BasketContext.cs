using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Basket.Infrastructure.Data.Contexts
{
    public class BasketContext
    {
        private readonly ConnectionMultiplexer _redis;
        public IDatabase Database { get; }

        public BasketContext(IConfiguration configuration)
        {
            _redis = ConnectionMultiplexer.Connect(configuration["CacheSettings:ConnectionString"]);
            Database = _redis.GetDatabase();
        }
    }
}
