using AutoMapper;
using MealOrdering.Server.Mapping;

namespace MealOrdering.Server.Extensions
{
    public static class MappingConfig
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }
}
