using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Concrete.Product.BusinessPass
{
    public class BusinessPassMobileCardOrder : IMobileCardOrder
    {
        public string GetOrder()
        {
            return "Created -BusinessPass- Order With -Mobile Cards-.";
        }
    }
}
