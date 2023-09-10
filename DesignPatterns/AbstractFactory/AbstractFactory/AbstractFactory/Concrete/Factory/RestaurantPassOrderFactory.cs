using AbstractFactory.Abstractions.Factory;
using AbstractFactory.Abstractions.Product;
using AbstractFactory.Concrete.Product.RestaurantPass;

namespace AbstractFactory.Concrete.Factory
{
    public class RestaurantPassOrderFactory : IOrderFactory
    {
        public IMobileCardOrder CreateMobileCardOrder()
        {
            return new RestaurantPassMobileCardOrder();
        }

        public IMobileChqOrder CreateMobileChqOrder()
        {
            return new RestaurantPassMobileChqOrder();
        }

        public IPhysicalCardOrder CreatePhysicalCardOrder()
        {
            return new RestaurantPassPhysicalCardOrder();
        }
    }
}
