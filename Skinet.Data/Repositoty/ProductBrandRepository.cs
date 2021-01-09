using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Data.Repositoty
{
    public class ProductBrandRepository : SkinetRepository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(SkinetContext context) : base(context) { }

    }
}