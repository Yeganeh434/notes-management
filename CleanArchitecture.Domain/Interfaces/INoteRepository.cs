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
        Task<IEnumerable<Note>> GetAllAsync(int userId);
        Task<Note?> GetByIdAsync(int userId,int noteId);
        Task<IEnumerable<Note>> FindByTitleAsync(string title);
        Task<IEnumerable<Note>> FindByContentAsync(string word);
    }
}
