using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockSolution.PortfolioService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.PortfolioService.Infrastructure.Database
{
    public class PortfolioDbcontext : DbContext
    {
        public PortfolioDbcontext(DbContextOptions options) : base(options)
        {
        }

        protected PortfolioDbcontext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Portfolio>(options =>
            {
                options.HasKey(x => x.Id);
                options.HasMany(x => x.Holdings).WithOne(x => x.Portfolio).HasForeignKey(x => x.PorfolioId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<PortfolioHolding>(options =>
            {
                options.HasKey(x => x.Id);
                options.HasIndex(x => new { x.PorfolioId, x.Symbol }).IsUnique();
            });
            modelBuilder.Entity<PortfolioTransaction>(options =>
            {
                options.HasKey(x => x.Id);
                options.HasOne(x => x.Portfolio).WithMany(x => x.Transactions).HasForeignKey(x => x.PortfolioId).OnDelete(DeleteBehavior.Cascade);
            });
        }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<PortfolioHolding> PortfolioHolding { get; set; }
        public DbSet<PortfolioTransaction> PortfolioTransaction { get; set; }
    }
}
