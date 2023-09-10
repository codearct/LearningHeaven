using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Concrete.Product.BusinessPass
{
    internal class BusinessPassPhysicalCardOrder : IPhysicalCardOrder
    {
        public string GetPhysicalCardOrder()
        {
            return "Created -BusinessPass- Order With -Physical Cards-.";
        }
    }
}
