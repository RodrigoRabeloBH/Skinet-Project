using System.Collections.Generic;

namespace Skinet.Model
{
    public class ProductBrand : Entity
    {
        public string Name { get; set; }

        // EF Relation
        public virtual IEnumerable<Product> Products { get; set; }
    }
}