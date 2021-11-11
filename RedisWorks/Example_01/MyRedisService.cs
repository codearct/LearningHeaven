using Newtonsoft.Json;
using StackExchange.Redis;

namespace LearnRedis
{
    partial class Program
    {
        public class MyRedisService
        {
            readonly IDatabase _redisDatabase;
            public MyRedisService(RedisConnectionManager redisConnectionManager)
                => _redisDatabase = redisConnectionManager.Connection.GetDatabase();

            public void Add(string key, object value)
            {
                var data = JsonConvert.SerializeObject(value);
                _redisDatabase.StringSet(key, data);
            }
            public object Get(string key)
            {
                var data = _redisDatabase.StringGet(key);
                var value = JsonConvert.DeserializeObject(data);
                return value;
            }
        }
    }
}
