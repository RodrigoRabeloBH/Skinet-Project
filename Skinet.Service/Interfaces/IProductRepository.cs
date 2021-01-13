using System.Collections.Generic;
using System.Threading.Tasks;
using Skinet.Model;

namespace Skinet.Service.Interfaces
{
    public interface IProductRepository : ISkinetRepository<Product>
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductsByBrandAndTypes(int? brandId, int? typeId, string sort);
    }
}