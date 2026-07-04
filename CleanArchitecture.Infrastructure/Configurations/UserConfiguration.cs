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
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .UseIdentityColumn();

            builder.Property(u => u.Username)
                .IsRequired();

            builder.HasIndex(u=>u.Username)
                .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();
        }
    }
}