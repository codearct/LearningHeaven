using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Concrete.Product.RestaurantPass
{
    public class RestaurantPassMobileCardOrder : IMobileCardOrder
    {
        public string GetOrder()
        {
            return "Created -RestaurantPass- Order With -Mobile Cards-.";
        }
    }
}
