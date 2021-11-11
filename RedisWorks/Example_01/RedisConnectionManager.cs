using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnRedis
{
    public class RedisConnectionManager
    {
        readonly Lazy<IConnectionMultiplexer> _connectionMultiplexer;
        public IConnectionMultiplexer Connection => _connectionMultiplexer.Value;
        public RedisConnectionManager(string connectionOptions)
            => _connectionMultiplexer = new Lazy<IConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionOptions));
    }
}
