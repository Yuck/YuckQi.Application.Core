using MediatR;
using YuckQi.Domain.Application.Queries.Abstract;
using YuckQi.Domain.Application.Queries.Results;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Abstract
{
    public abstract class SearchQueryBase<TEntity, TKey> : IRequest<Result<Page<TEntity, TKey>>>, ISearchQuery where TEntity : class, IEntity<TKey> where TKey : struct
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}