using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace LearnRedis
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var config = LoadConfiguration();

            var serviceProvider = LoadServices(config);

            var person = new Person
            {
                name = "Akif",
                surname = "Yıldız",
                age = 3
            };
            var person2 = new Person
            {
                name = "Ahmet",
                surname = "Yıldız",
                age = 6
            };

            var myRedisService = serviceProvider.GetService<MyRedisService>();
            myRedisService.Add("person2", person2);
            Console.WriteLine(myRedisService.Get("person2"));
        }

        static IServiceProvider LoadServices(IConfiguration configuration)
            => new ServiceCollection()
                    .AddRedis(configuration.GetConnectionString("Redis"))
                    .AddTransient<MyRedisService>()
                    .BuildServiceProvider();
        static IConfiguration LoadConfiguration()
            => new ConfigurationBuilder()
                    .AddJsonFile("app.config.json")
                    .Build();
    }
}
