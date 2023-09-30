using AbstractFactory.Abstractions.Factory;
using AbstractFactory.Abstractions.Product;
using AbstractFactory.Concrete.Product.BusinessPass;

namespace AbstractFactory.Concrete.Factory
{
    public class BusinessPassOrderFactory : IOrderFactory
    {
        public IMobileCardOrder CreateMobileCardOrder()
        {
            return new BusinessPassMobileCardOrder();
        }

        public IMobileChqOrder CreateMobileChqOrder()
        {
            return new BusinessPassMobileChqOrder();
        }

        public IPhysicalCardOrder CreatePhysicalCardOrder()
        {
            return new BusinessPassPhysicalCardOrder();
        }
    }
}
