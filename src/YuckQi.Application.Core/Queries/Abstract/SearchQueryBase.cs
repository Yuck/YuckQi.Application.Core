using System;
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

        protected SearchQueryBase(Int32 page, Int32 size)
        {
            PageCriteria = new Page(page, size);
        }

        #endregion
    }
}