using AbstractFactory.Abstractions.Product;

namespace AbstractFactory.Abstractions.Factory
{
    public interface IOrderFactory
    {
        IPhysicalCardOrder CreatePhysicalCardOrder();
        IMobileCardOrder CreateMobileCardOrder();
        IMobileChqOrder CreateMobileChqOrder();
    }
}
