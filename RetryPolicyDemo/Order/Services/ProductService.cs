using Order.Repositories;
using Polly;
using Polly.Retry;

namespace Order.Services
{
    public interface IProductService
    {
        string GetProductById(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISyncPolicy _faultPolicy;
        public ProductService(IProductRepository productRepository, ISyncPolicy faultPolicy)
        {
            _productRepository = productRepository;
            _faultPolicy = faultPolicy;
        }

        public string GetProductById(int id)
        {
            return _faultPolicy.Execute<string>(() => _productRepository.GetProductById(id));
        }
    }
}
