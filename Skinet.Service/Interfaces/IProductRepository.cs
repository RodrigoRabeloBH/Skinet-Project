using System.Collections.Generic;
using System.Threading.Tasks;
using Skinet.Model;

namespace Skinet.Service.Interfaces
{
    public interface IProductRepository : ISkinetRepository<Product>
    {
        Task<IEnumerable<Product>> GetProducts(string sort);
        Task<IEnumerable<Product>> GetProductsByType(int typeId, string sort);
        Task<IEnumerable<Product>> GetProductsByBrand(int brandId, string sort);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProductByName(string name);
    }
}