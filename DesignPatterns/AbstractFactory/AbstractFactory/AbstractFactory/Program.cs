
using AbstractFactory;
using AbstractFactory.Abstractions.Factory;
using AbstractFactory.Concrete.Factory;
using AbstractFactory.Concrete.Product.RestaurantPass;

IOrderFactory rpOrder = new RestaurantPassOrderFactory();
IOrderFactory bpOrder = new BusinessPassOrderFactory();

OrderService orderService = new OrderService(rpOrder);
Console.WriteLine(orderService.GetPhysicalCardOrder());

