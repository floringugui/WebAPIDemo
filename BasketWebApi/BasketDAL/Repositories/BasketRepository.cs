using BasketBL.Entities;
using BasketBL.Enums;
using BasketBL.Interfaces;
using BasketDAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketDAL.Repositories
{
    public class BasketRepository : RepositoryBase<Basket>
    {
        public BasketRepository(AppDbContext dbContext) : base(dbContext)
        { }

        public async Task<IEnumerable<Basket>> ListAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Basket> FindAsync(int id)
        {
            return await FindAsync(id);
        }
    }
}