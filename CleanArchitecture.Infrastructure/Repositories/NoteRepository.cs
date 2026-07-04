using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class NoteRepository:Repository<Note>, INoteRepository
    {
        public NoteRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Note>> GetAllAsync(int userId)
        {
            return await _dbSet.Where(n=>n.UserId == userId).ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(int userId, int noteId)
        {
            return await _dbSet.FirstOrDefaultAsync(n => n.UserId == userId && n.Id == noteId);
        }

        public async Task<IEnumerable<Note>> FindByTitleAsync(int userId, string title)
        {
            return await _dbSet.Where(n=>n.UserId==userId && n.Title.Contains(title)).ToListAsync();
        }

        public async Task<IEnumerable<Note>> FindByContentAsync(int userId, string word)
        {
            return await _dbSet.Where(n=>n.UserId==userId && n.Content.Contains(word)).ToListAsync();
        }
    }
}
