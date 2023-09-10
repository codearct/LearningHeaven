using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Concrete.Product.RestaurantPass
{
    public class RestaurantPassPhysicalCardOrder : IPhysicalCardOrder
    {
        public string GetPhysicalCardOrder()
        {
            return "Created -RestaurantPass- Order With -Physical Cards-.";
        }
    }
}
