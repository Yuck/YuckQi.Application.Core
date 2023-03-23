using System;
using MediatR;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects;
using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Application.Core.Queries.Abstract;

public abstract class SearchQueryBase<T> : IRequest<Result<IPage<T>>>
{
    public IPage PageCriteria { get; }

    protected SearchQueryBase(Int32 page, Int32 size)
    {
        PageCriteria = new Page(page, size);
    }
}
