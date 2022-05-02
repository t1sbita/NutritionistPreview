using NutritionistPreview.Api.Core.Domain.Entities.Base;
using NutritionistPreview.Api.Core.Util;
using System.Linq.Expressions;

namespace NutritionistPreview.Api.Infrastructure.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetById(long Id, params Expression<Func<T, object>>[] includes);

        T Get(Expression<Func<T, bool>> filters, params Expression<Func<T, object>>[] includes);

        List<T> GetAll(Expression<Func<T, bool>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortedBy = null,
            params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> filters = null,
            params Expression<Func<T, object>>[] includes);

        PageConsultation<T> GetAllPaged(int page, int itemsByPage,
            ICollection<Expression<Func<T, bool>>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortedBy = null,
            params Expression<Func<T, object>>[] includes);

        T Add(T Entity);
        void Attach(T entity);
        T Update(T Entity);
        bool Delete(long Id);
        bool Delete(T entityToDelete);
        void Save();
        void CreateTransaction();
        void Commit();
        void Rollback();
    }
}
