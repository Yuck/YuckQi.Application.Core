using MediatR;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects;

namespace YuckQi.Application.Core.Abstract
{
    public abstract class SearchQueryBase<TEntity, TKey> : IRequest<Result<Page<TEntity>>> where TEntity : class, IEntity<TKey> where TKey : struct
    {
        #region Properties

        protected Page PageCriteria { get; }

        #endregion


        #region Constructors

        protected SearchQueryBase(int page, int size)
        {
            PageCriteria = new Page(page, size);
        }

        #endregion
    }
}