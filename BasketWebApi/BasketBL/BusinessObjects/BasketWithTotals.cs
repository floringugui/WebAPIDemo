using BasketBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBL.BusinessObjects
{
    public class BasketWithTotals
    {
        private Basket _basket;

        public BasketWithTotals(Basket basket)
        {
            _basket = basket;
        }

        public Basket Basket
        {
            get
            {
                return _basket;
            }
        }

        public double TotalNet
        {
            get
            {
                return BasketTotalCalculator.GetTotalNet(_basket);
            }
        }

        public double TotalGross
        {
            get
            {
                return BasketTotalCalculator.GetTotalGross(_basket);
            }
        }
    }
}