using BasketBL.BusinessObjects;
using BasketBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBL.Interfaces.Services
{
    public interface IBasketService
    {
        Task<Basket> GetOne(int id);

        Task<BasketWithTotals> GetOneWithTotals(int id);

        Task Update(Basket basket);

        Task<int> Add(Basket basket);
    }
}