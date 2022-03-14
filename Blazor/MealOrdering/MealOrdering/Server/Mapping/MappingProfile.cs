using AutoMapper;
using MealOrdering.Shared.DTO;
using MealOrdering.Server.Data;
using MealOrdering.Server.Data.Models;

namespace MealOrdering.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<Supplier, SupplierDTO>()
                .ReverseMap();

            CreateMap<User, UserDTO>();

            CreateMap<UserDTO, User>()
                .ReverseMap();

            CreateMap<Order, OrderDTO>()
                .ForMember(x => x.SupplierName, y => y.MapFrom(z => z.Supplier.Name))
                .ForMember(x => x.CreatedUserFullName, y => y.MapFrom(z => z.CreatedUser.FirstName + " " + z.CreatedUser.LastName));

            CreateMap<OrderDTO, Order>();



            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(x => x.CreatedUserFullName, y => y.MapFrom(z => z.CreatedUser.FirstName + " " + z.CreatedUser.LastName))
                .ForMember(x => x.OrderName, y => y.MapFrom(z => z.Order.Name ?? ""));

            CreateMap<OrderItemDTO, OrderItem>();
        }
    }
}