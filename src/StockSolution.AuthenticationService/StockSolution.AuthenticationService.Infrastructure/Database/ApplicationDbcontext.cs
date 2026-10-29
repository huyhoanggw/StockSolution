using Microsoft.EntityFrameworkCore;
using StockSolution.AuthenticationService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Infrastructure.Database
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbcontext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(options =>
            {
                options.HasKey(x => x.Id);
                options.Property(x => x.UserName).IsRequired();
                options.Property(x => x.Email).IsRequired();
                options.Property(x => x.PasswordHash).IsRequired();
                options.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Permission>().HasKey(x => x.Id);
            modelBuilder.Entity<Role>().HasKey(x => x.Id);
            modelBuilder.Entity<RolePermission>(options =>
            {
                options.HasKey(x => new { x.RoleId, x.PermissionId });
                options.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
                options.HasOne(x => x.Permission).WithMany().HasForeignKey(x => x.PermissionId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
