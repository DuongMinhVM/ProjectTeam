using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityLayer;

namespace EntityService.IServices
{
    public interface IBaseService<TModel, TViewModel>
        where TModel : BaseEntity
        where TViewModel : class
    {
        Task<TViewModel> AddAsync(TViewModel model);

        Task<TViewModel> DeleteAsync(TViewModel model);

        Task<TViewModel> UpdateAsync(TViewModel model);

        IEnumerable<TViewModel> FindByExpression(TViewModel mapper, Expression<Func<TViewModel, bool>> predicate);
    }
}