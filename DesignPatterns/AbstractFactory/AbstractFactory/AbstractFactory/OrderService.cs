using AbstractFactory.Abstractions.Factory;
using AbstractFactory.Abstractions.Product;

namespace AbstractFactory
{
    public class OrderService
    {
        private readonly IMobileCardOrder _mobileCardOrder;
        private readonly IMobileChqOrder _mobileChqOrder;
        private readonly IPhysicalCardOrder _physicalCardOrder;
        public OrderService(IOrderFactory orderFactory)
        {
            _mobileCardOrder = orderFactory.CreateMobileCardOrder();
            _mobileChqOrder = orderFactory.CreateMobileChqOrder();
            _physicalCardOrder = orderFactory.CreatePhysicalCardOrder();
        }
        public string GetMobileCardOrder()
        {
            return _mobileCardOrder.GetMobileCardOrder();
        }
        public string GetMobileChqOrder()
        {
            return _mobileChqOrder.GetMobileChqOrder();
        }
        public string GetPhysicalCardOrder()
        {
            return _physicalCardOrder.GetPhysicalCardOrder();
        }
    }
}
