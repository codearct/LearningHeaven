using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Concrete.Product.BusinessPass
{
    public class BusinessPassMobileCardOrder : IMobileCardOrder
    {
        public string GetMobileCardOrder()
        {
            return "Created -BusinessPass- Order With -Mobile Cards-.";
        }
    }
}
