using AbstractFactory.Abstract_Func.Factory;

namespace AbstractFactory.Concrete_Func.Factory
{
    public static class BusinessPassOrderFactory
    {
        public static string CreateOrder(Func<string> createBusinessPassOrder)
        {
            return OrderFactory.CreateOrder(createBusinessPassOrder);
        }
    }
}
