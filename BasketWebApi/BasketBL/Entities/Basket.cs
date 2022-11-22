using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBL.Entities
{
    public class Basket : EntityBase<int>

    {
        public int TotalNet { get; set; }
        public int TotalGross { get; set; }
        public string Customer { get; set; }
        public bool paysVAT { get; set; }
        public List<Article> Articles { get; set; }
    }
}