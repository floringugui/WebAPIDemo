using BasketBL.Entities;
using BasketBL.Interfaces.Services;
using BasketBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketServices
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Article>> GetAll()
        {
            return await _unitOfWork.Repository<Article>().GetAllAsync();
        }

        public async Task<Article> GetOne(int id)
        {
            return await _unitOfWork.Repository<Article>().FindAsync(id);
        }

        public async Task Update(Article articleParam)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var articleRepos = _unitOfWork.Repository<Article>();
                var article = await articleRepos.FindAsync(articleParam.Id);
                if (article == null)
                {
                    throw new KeyNotFoundException();
                }

                // TODO: Implement the update of the props
                //article. = article.Name;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<int> Add(Article articleParam)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var articleRepos = _unitOfWork.Repository<Article>();
                await articleRepos.InsertAsync(articleParam);

                await _unitOfWork.CommitTransaction();

                return articleParam.Id;
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}