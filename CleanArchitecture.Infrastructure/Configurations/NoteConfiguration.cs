using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class NoteConfiguration:IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");

            builder.HasKey(n => n.Id);

            builder.Property(n=>n.Id)
                .UseIdentityColumn();

            builder.Property(n => n.Title)
                .IsRequired();

            builder.Property(n=>n.Content)
                .IsRequired();

            builder.Property(n => n.UserId)
                .IsRequired();

            builder.HasOne(n=>n.User)
                .WithMany(n=>n.Notes)
                .HasForeignKey(n=>n.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
