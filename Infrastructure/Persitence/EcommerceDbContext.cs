using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persitence
{
    public class EcommerceDbContext : IdentityDbContext<Usuario>
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options): base(options) { 
        }
        
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Image>? Images { get; set; }

        public DbSet<Address>? Addresses { get; set; }

        public DbSet<OrderItems>? OrderItems { get; set; }

    }
}
