using AutoMapper;
using DataAccessLayer.IRepositorys;
using DataAccessLayer.IUnitOfWorks;
using EntityLayer;
using EntityService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityService.Services
{
    public class BaseService<TModel, TViewModel> : IBaseService<TModel, TViewModel> where TModel : BaseEntity where TViewModel : class
    {
        private readonly IRepository<TModel> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TModel>();
        }

        public virtual async Task<TViewModel> AddAsync(TViewModel model)
        {
            TModel mapper = Mapper.Map<TModel>(model);
            TModel result = _repository.Add(mapper);
            TViewModel data = Mapper.Map<TViewModel>(result);
            return await _unitOfWork.CommitAsync() > 0 ? data : null;
        }

        public virtual async Task<TViewModel> DeleteAsync(TViewModel model)
        {
            TModel mapper = Mapper.Map<TModel>(model);
            mapper = _repository.Add(mapper);
            return await _unitOfWork.CommitAsync() > 0 ? Mapper.Map<TViewModel>(mapper) : null;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.

        public virtual async Task<bool> ExistsAsync(Expression<Func<TViewModel, bool>> predicate)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.

        public async Task<IEnumerable<TViewModel>> FindBy(Expression<Func<TViewModel, bool>> predicate)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.

        public async Task<IEnumerable<TViewModel>> FindBy(Expression<Func<TViewModel, bool>> predicate, string include)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TViewModel> Get(params object[] keyValues)
        {
            TModel result = await _repository.Get(keyValues);
            return Mapper.Map<TViewModel>(result);
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAll()
        {
            IQueryable<TModel> result = await _repository.GetAll();
            return Mapper.Map<TModel[], IEnumerable<TViewModel>>(result.ToArray());
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAll(string include)
        {
            IQueryable<TModel> result = await _repository.GetAll(include);
            return Mapper.Map<TModel[], IEnumerable<TViewModel>>(result.ToArray());
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAll(int page, int pageCount)
        {
            System.Linq.IQueryable<TModel> result = await _repository.GetAll(page, pageCount);
            return Mapper.Map<TModel[], IEnumerable<TViewModel>>(result.ToArray());
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAll(string include, string include2)
        {
            System.Linq.IQueryable<TModel> result = await _repository.GetAll(include, include2);
            return Mapper.Map<TModel[], IEnumerable<TViewModel>>(result.ToArray());
        }

        public virtual async Task<TViewModel> GetBy(Guid key)
        {
            TModel result = await _repository.Get(key);
            return Mapper.Map<TViewModel>(result);
        }

        public virtual async Task<TViewModel> GetByAsync(Guid key)
        {
            TModel result = await _repository.GetAsync(key);
            return Mapper.Map<TViewModel>(result);
        }

        public virtual async Task<TViewModel> UpdateAsync(TViewModel model)
        {
            TModel mapper = Mapper.Map<TModel>(model);
            _repository.Update(mapper);
            return await _unitOfWork.CommitAsync() > 0 ? Mapper.Map<TViewModel>(mapper) : null;
        }
    }
}