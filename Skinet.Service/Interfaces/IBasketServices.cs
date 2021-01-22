using System.Threading.Tasks;
using Skinet.Model;

namespace Skinet.Service.Interfaces
{
    public interface IBasketServices
    {
        decimal CalculeteTotals(CustomerBasket basket);
        decimal CalculeteItemTotal(BasketItem item);
    }
}