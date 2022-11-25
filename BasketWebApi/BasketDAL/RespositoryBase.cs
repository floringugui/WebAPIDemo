using BasketBL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketDAL.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        public DbSet<T> Entities => DbContext.Set<T>();

        public DbContext DbContext { get; private set; }

        public RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await Entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            return await Entities.FindAsync(keyValues);
        }

        public async Task InsertAsync(T entity, bool saveChanges = true)
        {
            await Entities.AddAsync(entity);

            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }
    }
}