using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Concrete.Product.BusinessPass
{
    internal class BusinessPassMobileChqOrder : IMobileChqOrder
    {
        public string GetMobileChqOrder()
        {
            return "Created -BusinessPass- Order With -Mobile Cheqeues-.";
        }
    }
}
