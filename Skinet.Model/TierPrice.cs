using System.Collections.Generic;

namespace Skinet.Model
{
    public class TierPrice : Entity
    {
        public string Description { get; set; }
        public double Percent { get; set; }

        // EF Relation
        public virtual IEnumerable<Product> Products { get; set; }
    }
}