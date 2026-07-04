using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
