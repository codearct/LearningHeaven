using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Concrete.Product.RestaurantPass
{
    public class RestaurantPassMobileChqOrder : IMobileChqOrder
    {
        public string GetOrder()
        {
            return "Created -RestaurantPass- Order With -Mobile Cheqeues-.";
        }
    }
}
