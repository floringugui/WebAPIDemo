using BasketBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBL.Interfaces.Services
{
    public interface IArticleService
    {
        Task<IList<Article>> GetAll();

        Task<Article> GetOne(int id);

        Task Update(Article article);

        Task<int> Add(Article article);
    }
}