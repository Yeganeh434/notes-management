using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface INoteRepository:IRepository<Note>
    {
        Task<IEnumerable<Note>> GetAllAsync(int userId,CancellationToken cancellationToken);
        Task<Note?> GetByIdAsync(int userId,int noteId, CancellationToken cancellationToken);
        Task<IEnumerable<Note>> FindByTitleAsync(int userId, string title, CancellationToken cancellationToken);
        Task<IEnumerable<Note>> FindByContentAsync(int userId, string word, CancellationToken cancellationToken);
    }
}
