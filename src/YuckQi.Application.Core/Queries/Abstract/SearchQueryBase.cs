using MediatR;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects;
using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Application.Core.Queries.Abstract
{
    public abstract class SearchQueryBase<T> : IRequest<Result<IPage<T>>>
    {
        #region Properties

        public IPage PageCriteria { get; }

        #endregion


        #region Constructors

        protected SearchQueryBase(int page, int size)
        {
            PageCriteria = new Page(page, size);
        }

        #endregion
    }
}