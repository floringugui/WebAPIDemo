using BasketBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBL.BusinessObjects
{
    public static class BasketTotalCalculator

    {
        private const double VAT_VALUE = 0.9;

        public static double GetTotalGross(Basket basket)
        {
            return basket.Articles
                .Sum(x => x.Price);
        }

        public static double GetTotalNet(Basket basket)
        {
            var totalNetWithNoVAT = GetTotalGross(basket);

            return basket.paysVAT
                ? totalNetWithNoVAT * VAT_VALUE
                : totalNetWithNoVAT;
        }
    }
}