﻿using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia
{

    public class EcommerceDbContext : IdentityDbContext<Usuario>
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasMany(p => p.products)
                .WithOne(r => r.Category)
                .HasForeignKey(r => r.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Product>()
                .HasMany(p => p.reviews)
                .WithOne(r => r.product)
                .HasForeignKey(r => r.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
              .HasMany(p => p.images)
              .WithOne(r => r.Product)
              .HasForeignKey(r => r.ProductId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<ShoppingCart>()
          .HasMany(p => p.ShoppingCartItems)
          .WithOne(r => r.ShoppingCart)
          .HasForeignKey(r => r.ShoppingCartId)
          .IsRequired()
          .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Usuario>().Property(x => x.Id).HasMaxLength(36);
            builder.Entity<Usuario>().Property(x => x.NormalizedUserName).HasMaxLength(90);
            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(90);
            builder.Entity<IdentityRole>().Property(x => x.NormalizedName).HasMaxLength(90);

        }


        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Image>? Images { get; set; }

        public DbSet<Address>? Addresses { get; set; }

        public DbSet<OrderItems>? OrderItems { get; set; }

        public DbSet<Review>?Reviews { get; set; }

        public DbSet<ShoppingCart>ShoppingCarts { get; set; }

        public DbSet<ShoppingCartItem>? ShoppingCartItems { get; set; }

        public DbSet<Country>Countries { get; set; }

        public DbSet<OrderAddres>OrderAddres { get; set; } 


    } 

}
    

