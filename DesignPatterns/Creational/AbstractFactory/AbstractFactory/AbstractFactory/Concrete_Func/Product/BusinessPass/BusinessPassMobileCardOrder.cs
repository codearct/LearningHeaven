using AbstractFactory.Abstract_Func.Product;

namespace AbstractFactory.Concrete_Func.Product.BusinessPass
{
    public static class BusinessPassMobileCardOrder
    {
        public static string GetOrder()
        {
            return MobileCardOrder.GetOrder(() =>
            {
                return "Created -BusinessPass- Order With -Mobile Cards-.";
            });
        }
    }
}
