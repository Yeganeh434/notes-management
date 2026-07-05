using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellationToken);
        void Delete(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
