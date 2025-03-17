using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Image : BaseDomainModel
    {
        [Column(TypeName ="NVARCHAR(4000")]
        public string? Url { get; set; }

        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }


        [Column(TypeName = "NVARCHAR(100)")]
        public string?  ProductCode { get; set; }


    }
}
