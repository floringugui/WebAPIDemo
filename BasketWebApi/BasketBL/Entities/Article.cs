using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBL.Entities
{
    public class Article : EntityBase<int>
    {
        public string Name { get; set; }
        public double Price { get; set; }

        [ForeignKey("basketId")]
        public virtual Basket Basket { get; set; }
    }
}