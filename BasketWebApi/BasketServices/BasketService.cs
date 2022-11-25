using BasketBL.BusinessObjects;
using BasketBL.Entities;
using BasketBL.Interfaces;
using BasketBL.Interfaces.Services;

namespace BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Basket> GetOne(int id)
        {
            return await _unitOfWork.Repository<Basket>().FindAsync(id);
        }

        public async Task<BasketWithTotals> GetOneWithTotals(int id)
        {
            var basket = await _unitOfWork.Repository<Basket>().FindAsync(id);

            return new BasketWithTotals(basket);
        }

        public async Task Update(Basket basketParam)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var basketRepos = _unitOfWork.Repository<Basket>();
                var basket = await basketRepos.FindAsync(basketParam.Id);
                if (basket == null)
                {
                    throw new KeyNotFoundException();
                }

                basket.Status = basketParam.Status;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<int> Add(Basket basketParam)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var basketRepos = _unitOfWork.Repository<Basket>();
                await basketRepos.InsertAsync(basketParam);

                await _unitOfWork.CommitTransaction();

                return basketParam.Id;
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}