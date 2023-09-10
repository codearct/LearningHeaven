using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Concrete.Product.RestaurantPass
{
    public class RestaurantPassMobileChqOrder : IMobileChqOrder
    {
        public string GetMobileChqOrder()
        {
            return "Created -RestaurantPass- Order With -Mobile Cheqeues-.";
        }
    }
}
