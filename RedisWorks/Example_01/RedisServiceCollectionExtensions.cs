using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnRedis
{
    public static class RedisServiceCollectionExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection serviceCollection,string configurationOptions)
        {
            serviceCollection.AddSingleton(new RedisConnectionManager(configurationOptions));
            return serviceCollection;
        }
    }
}
