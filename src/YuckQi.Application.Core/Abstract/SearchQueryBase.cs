using MediatR;
using YuckQi.Domain.Application.Queries.Results;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Abstract
{
    public abstract class SearchQueryBase<TEntity, TKey> : Page, IRequest<Result<Page<TEntity, TKey>>> where TEntity : class, IEntity<TKey> where TKey : struct
    {
        protected SearchQueryBase(int number, int size) : base(number, size)
        {
        }
    }
}