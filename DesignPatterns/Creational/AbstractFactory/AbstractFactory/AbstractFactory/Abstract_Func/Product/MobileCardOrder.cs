namespace AbstractFactory.Abstract_Func.Product
{
    public static class MobileCardOrder
    {
        public static string GetOrder(Func<string> getOrder)
        {
            return getOrder();
        }
    }
}
