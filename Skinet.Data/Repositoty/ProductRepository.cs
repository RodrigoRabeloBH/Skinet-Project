using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Data.Repositoty
{
    public class ProductRepository : SkinetRepository<Product>, IProductRepository
    {
        public ProductRepository(SkinetContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProducts(string sort)
        {
            var products = new List<Product>();

            switch (sort)
            {
                case "priceAsc":
                    products = await _context.Product
                        .AsNoTracking()
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .Include(p => p.TierPrice)
                        .OrderBy(p => p.Price)
                        .ToListAsync();
                    break;

                case "priceDesc":
                    products = await _context.Product
                       .AsNoTracking()
                       .Include(p => p.ProductBrand)
                       .Include(p => p.ProductType)
                       .Include(p => p.TierPrice)
                       .OrderByDescending(p => p.Price)
                       .ToListAsync();
                    break;

                default:
                    products = await _context.Product
                       .AsNoTracking()
                       .Include(p => p.ProductBrand)
                       .Include(p => p.ProductType)
                       .Include(p => p.TierPrice)
                       .OrderBy(p => p.Name)
                       .ToListAsync();
                    break;
            }
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var products = await GetProducts(null);

            return products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var products = await GetProducts(null);

            return products.Where(p => p.Name.Contains(name));
        }

        public async Task<IEnumerable<Product>> GetProductsByBrand(int brandId, string sort)
        {
            var products = await GetProducts(sort);

            return products.Where(p => p.ProductBrandId == brandId);
        }

        public async Task<IEnumerable<Product>> GetProductsByType(int typeId, string sort)
        {
            var products = await GetProducts(sort);

            return products.Where(p => p.ProductTypeId == typeId);
        }

    }
}