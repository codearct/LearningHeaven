using Order.Repositories;

namespace Order.Services
{
    public interface IProductService
    {
        string GetProductById(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public string GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}
