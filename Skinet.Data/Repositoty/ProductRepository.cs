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
        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .Include(p => p.TierPrice)
                    .FirstAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Product>> GetProductByName(string search)
        {
            return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .Include(p => p.TierPrice)
                    .Where(p => p.Name.Contains(search))
                    .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsByBrandAndTypes(int? brandId, int? typeId, string sort)
        {
            if (brandId.HasValue && typeId.HasValue)
            {
                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .Include(p => p.TierPrice)
                    .Where(p => p.ProductBrandId == brandId && p.ProductTypeId == typeId)
                    .ToListAsync();
            }
            else if (brandId.HasValue && !typeId.HasValue)
            {
                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .Include(p => p.TierPrice)
                    .Where(p => p.ProductBrandId == brandId)
                    .ToListAsync();
            }
            else if (!brandId.HasValue && typeId.HasValue)
            {
                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .Include(p => p.TierPrice)
                    .Where(p => p.ProductTypeId == typeId)
                    .ToListAsync();
            }
            else
            {
                var products = new List<Product>();

                switch (sort)
                {
                    case "priceAsc":
                        products = await _context.Products
                            .AsNoTracking()
                            .Include(p => p.ProductBrand)
                            .Include(p => p.ProductType)
                            .Include(p => p.TierPrice)
                            .OrderBy(p => p.Price)
                            .ToListAsync();
                        break;

                    case "priceDesc":
                        products = await _context.Products
                           .AsNoTracking()
                           .Include(p => p.ProductBrand)
                           .Include(p => p.ProductType)
                           .Include(p => p.TierPrice)
                           .OrderByDescending(p => p.Price)
                           .ToListAsync();
                        break;

                    default:
                        products = await _context.Products
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
        }
    }
}