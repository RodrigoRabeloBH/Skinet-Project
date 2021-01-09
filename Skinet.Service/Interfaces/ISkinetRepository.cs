using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Skinet.Model;

namespace Skinet.Service.Interfaces
{
    public interface ISkinetRepository<T> : IDisposable where T : Entity
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
