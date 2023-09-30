using AbstractFactory.Abstract_Func.Factory;

namespace AbstractFactory.Concrete_Func.Factory
{
    public static class RestaurantPassOrderFactory
    {
        public static string CreateOrder(Func<string> createRestaurantPassOrder)
        {
            return OrderFactory.CreateOrder(createRestaurantPassOrder);
        }
    }
}
