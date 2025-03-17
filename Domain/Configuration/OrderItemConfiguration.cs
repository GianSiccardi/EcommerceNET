using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> buidler)
        {
            buidler.Property(x => x.Price).HasColumnType("decimal(10,2)");
        }

    }
}
