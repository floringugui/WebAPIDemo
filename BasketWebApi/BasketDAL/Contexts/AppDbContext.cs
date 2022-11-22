using BasketBL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasketDAL.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("article");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("basket");

                entity.Property(e => e.Customer)
                    .HasMaxLength(255);

                entity.Property(e => e.TotalNet)
                    .IsRequired();

                entity.Property(e => e.TotalGross)
                    .IsRequired();
            });
        }
    }
}