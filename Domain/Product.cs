using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public  class Product : BaseDomainModel
    {

        [Column(TypeName = "NVARCHAR(100)")]
        public string? Nombre { get; set; }
        [Column(TypeName = "DECIMAL(10 , 2)")]
        public decimal Precio { get; set; }

        [Column(TypeName = "NVARCHAR(4000)")]
        public string? Descripcion { get; set; } 

        public int Raiting { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        public string? Seller{ get; set; }

        public int Stokc { get; set; }

        public ProductStatus Status { get; set; } = ProductStatus.Activo;

        public int CategoryId { get; set; }

        public  Category? Category { get; set; }


        public virtual ICollection<Review>? reviews { get; set; }

        public virtual ICollection<Image>? images { get; set; }

    }

}
