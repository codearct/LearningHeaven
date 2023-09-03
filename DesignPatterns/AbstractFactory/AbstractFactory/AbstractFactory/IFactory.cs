namespace AbstractFactory
{
    public interface IFactory
    {
        ProductA CreateProductA();
        ProductB CreateProductB();
    }
}
