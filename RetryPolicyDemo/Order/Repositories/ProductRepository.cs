namespace Order.Repositories
{
    public interface IProductRepository
    {
        string GetProductById(int id);
    }
    public class ProductRepository : IProductRepository
    {
        private Dictionary<int, string>? _productList = null;
        public ProductRepository()
        {
            if(_productList == null)
            {
                _productList = new Dictionary<int, string>();
                _productList.Add(1, "Restaurant");
                _productList.Add(2, "Gift");
                _productList.Add(3, "Transportation");
            }
        }

        public string GetProductById(int id)
        {
            Console.WriteLine("We are in Product Repository");
            ThrowRandomException();
            return _productList![id];
        }

        private void ThrowRandomException()
        {
            var randomNumber = new Random().Next(0, 10);
            if(randomNumber > 5)
            {
                Console.WriteLine("Error! Throwing exception...");
                throw new Exception("Exception from Product Repository");
            }
        }
    }
}
