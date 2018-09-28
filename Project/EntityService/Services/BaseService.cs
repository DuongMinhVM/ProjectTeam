﻿using AutoMapper;
using DataAccessLayer.IRepository;
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
        internal IRepository<TModel> repository;
        internal IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = unitOfWork.GetRepository<TModel>();
        }

        public virtual async Task<TViewModel> AddAsync(TViewModel model)
        {
            TModel mapper = Mapper.Map<TModel>(model);
            TModel result = repository.Add(mapper);
            TViewModel data = Mapper.Map<TViewModel>(result);
            return await unitOfWork.CommitAsync() > 0 ? data : null;
        }

        public virtual async Task<TViewModel> DeleteAsync(TViewModel model)
        {
            TModel mapper = Mapper.Map<TModel>(model);
            mapper = repository.Add(mapper);
            return await unitOfWork.CommitAsync() > 0 ? Mapper.Map<TViewModel>(mapper) : null;
        }

        public virtual IEnumerable<TViewModel> FindByExpression(TViewModel viewModel, Expression<Func<TViewModel, bool>> pridicate)
        {
            TModel mapper = Mapper.Map<TModel>(viewModel);
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }
            IEnumerable<TModel> result = repository.FindBy(pridicate as Expression<Func<TModel, bool>>);
            return result as IEnumerable<TViewModel>;
        }

        public async Task<TViewModel> UpdateAsync(TViewModel model)
        {
            TModel mapper = Mapper.Map<TModel>(model);
            repository.Update(mapper);
            return await unitOfWork.CommitAsync() > 0 ? Mapper.Map<TViewModel>(mapper) : null;
        }
    }
}