namespace AbstractFactory.Abstract_Func.Factory
{
    public static class OrderFactory
    {
        public static string CreateOrder(Func<string> createOrder)
        {
            return createOrder();
        }
    }
}
