using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBL.Entities
{
    public class Article : EntityBase<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}