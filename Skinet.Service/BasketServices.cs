using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Service
{
    public class BasketServices : IBasketServices
    {
        public decimal CalculeteItemTotal(BasketItem item)
        {

            if (item.TierPriceId == 2 && item.Quantity % 2 == 0)
            {
                return item.Price * (decimal)item.Quantity * (decimal)item.Percent;
            }
            else if (item.TierPriceId == 1 && item.Quantity % 3 == 0)
            {
                return 10 * (decimal)item.Quantity * (decimal)item.Percent;
            }
            else
            {
                return item.Price * item.Quantity;
            }
        }

        public decimal CalculeteTotals(CustomerBasket basket)
        {

            decimal total = 0;

            foreach (var item in basket.Items)
            {
                if (item.TierPriceId == 2 && item.Quantity % 2 == 0)
                {

                    total += item.Price * (decimal)item.Quantity * (decimal)item.Percent;

                }
                else if (item.TierPriceId == 1 && item.Quantity % 3 == 0)
                {

                    total += 10 * item.Quantity * (decimal)item.Percent;
                }
                else
                {
                    total += item.Price * item.Quantity;
                }
            }
            return total;
        }
    }
}