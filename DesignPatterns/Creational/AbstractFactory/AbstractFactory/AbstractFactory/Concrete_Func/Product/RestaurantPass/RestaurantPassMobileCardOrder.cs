using AbstractFactory.Abstract_Func.Product;

namespace AbstractFactory.Concrete_Func.Product.RestaurantPass
{
    public static class RestaurantPassMobileCardOrder
    {
        public static void GetOrder()
        {
            MobileCardOrder.GetOrder(() =>
            {
                return "Created -RestaurantPass- Order With -Mobile Cards-.";
            });
        }
    }
}
