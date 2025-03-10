using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Category :BaseDomainModel
    {
        [Column(TypeName="NVACHAR(100)")]
        public string? Name { get; set; }

    }
}
