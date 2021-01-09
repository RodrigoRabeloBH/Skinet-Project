using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Data.Repositoty
{
    public class TierPriceRepository : SkinetRepository<TierPrice>, ITierPriceRepository
    {
        public TierPriceRepository(SkinetContext context) : base(context) { }
    }
}