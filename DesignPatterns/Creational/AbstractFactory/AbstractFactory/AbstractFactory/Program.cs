using AbstractFactory.Concrete_Func.Factory;
using AbstractFactory.Concrete_Func.Product.BusinessPass;

//using AbstractFactory.Concrete.Factory;

//var bpOrder = new BusinessPassOrderFactory();
//var mobileCardOrder = bpOrder.CreateMobileCardOrder();

//Console.WriteLine(mobileCardOrder.GetOrder());

var mobileCardOrder = () => BusinessPassMobileCardOrder.GetOrder();

var bpOrder = BusinessPassOrderFactory.CreateOrder(mobileCardOrder);
Console.WriteLine(bpOrder);

