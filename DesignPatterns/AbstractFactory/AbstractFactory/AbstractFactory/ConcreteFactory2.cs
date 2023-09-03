namespace AbstractFactory
{
    public class ConcreteFactory2 : IFactory
    {
        public ProductA CreateProductA()
        {
            return new ProductA();
        }
        public ProductB CreateProductB()
        {
            return new ProductB();
        }
    }
}
