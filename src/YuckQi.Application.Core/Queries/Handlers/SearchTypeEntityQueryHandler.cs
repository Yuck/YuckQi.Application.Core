using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Services.Abstract;
using YuckQi.Domain.Services.Models;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects.Abstract;

namespace YuckQi.Application.Core.Queries.Handlers
{
    public class SearchTypeEntityQueryHandler<TTypeEntity, TKey> : IRequestHandler<SearchTypeEntityQuery<TTypeEntity, TKey>, Result<IPage<TTypeEntity>>> where TTypeEntity : IEntity<TKey>, IType where TKey : struct
    {
        #region Private Members

        private readonly ITypeEntityService<TTypeEntity, TKey> _types;

        #endregion


        #region Constructors

        public SearchTypeEntityQueryHandler(ITypeEntityService<TTypeEntity, TKey> types)
        {
            _types = types ?? throw new ArgumentNullException(nameof(types));
        }

        #endregion


        #region Public Methods

        public Task<Result<IPage<TTypeEntity>>> Handle(SearchTypeEntityQuery<TTypeEntity, TKey> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return _types.SearchAsync(request.Adapt<TypeSearchCriteria>());
        }

        #endregion
    }
}
