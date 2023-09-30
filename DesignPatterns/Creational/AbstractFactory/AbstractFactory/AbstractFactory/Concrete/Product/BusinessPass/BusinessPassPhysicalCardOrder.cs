using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Concrete.Product.BusinessPass
{
    internal class BusinessPassPhysicalCardOrder : IPhysicalCardOrder
    {
        public string GetOrder()
        {
            return "Created -BusinessPass- Order With -Physical Cards-.";
        }
    }
}
