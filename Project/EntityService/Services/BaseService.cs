using AutoMapper;
using DataAccessLayer.IRepositorys;
using DataAccessLayer.IUnitOfWorks;
using EntityLayer;
using EntityService.IServices;
using System;
using System.Collections.Generic;
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

        public virtual IEnumerable<TViewModel> FindByExpression(TViewModel viewModel, Expression<Func<TViewModel, bool>> predicate)
        {
            TModel mapper = Mapper.Map<TModel>(viewModel);
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }
            IEnumerable<TModel> result = _repository.FindBy(null);
            return result as IEnumerable<TViewModel>;
        }

        public async Task<TViewModel> UpdateAsync(TViewModel model)
        {
            TModel mapper = Mapper.Map<TModel>(model);
            _repository.Update(mapper);
            return await _unitOfWork.CommitAsync() > 0 ? Mapper.Map<TViewModel>(mapper) : null;
        }
    }
}