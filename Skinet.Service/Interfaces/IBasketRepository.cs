using System.Threading.Tasks;
using Skinet.Model;

namespace Skinet.Service.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasket(string basketId);
        Task<CustomerBasket> Update(CustomerBasket basket);
        Task<bool> DeleteBasket(string basketId);
    }
}