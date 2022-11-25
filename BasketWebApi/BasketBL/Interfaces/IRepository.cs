using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Entities { get; }
        DbContext DbContext { get; }

        Task<IList<T>> GetAllAsync();

        Task<T> FindAsync(params object[] keyValues);

        Task InsertAsync(T entity, bool saveChanges = true);
    }
}