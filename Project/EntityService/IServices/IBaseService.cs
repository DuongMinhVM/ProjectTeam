using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityService.IServices
{
    public interface IBaseService<TModel, TViewModel>
        where TModel : BaseEntity
        where TViewModel : class
    {
        Task<TViewModel> AddAsync(TViewModel model);

        Task<TViewModel> DeleteAsync(TViewModel model);

        Task<TViewModel> UpdateAsync(TViewModel model);

        Task<TViewModel> GetByAsync(Guid key);

        Task<TViewModel> GetBy(Guid key);

        Task<TViewModel> Get(params object[] keyValues);

        Task<IEnumerable<TViewModel>> FindBy(Expression<Func<TViewModel, bool>> predicate);

        Task<IEnumerable<TViewModel>> FindBy(Expression<Func<TViewModel, bool>> predicate, string include);

        Task<IEnumerable<TViewModel>> GetAll();

        Task<IEnumerable<TViewModel>> GetAll(string include);

        Task<IEnumerable<TViewModel>> GetAll(int page, int pageCount);

        Task<IEnumerable<TViewModel>> GetAll(string include, string include2);

        Task<bool> ExistsAsync(Expression<Func<TViewModel, bool>> predicate);
    }
}