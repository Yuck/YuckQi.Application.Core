using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using YuckQi.Domain.Application.Queries.Results;
using YuckQi.Domain.Entities.Types;
using YuckQi.Domain.Services.Abstract;
using YuckQi.Domain.Services.Models;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core
{
    internal class TypeSearchQueryHandler<TKey> : IRequestHandler<TypeSearchQuery<TypeEntityBase<TKey>, TKey>, Result<Page<TypeEntityBase<TKey>, TKey>>> where TKey : struct
    {
        #region Private Members

        private readonly ITypeEntityService<TypeEntityBase<TKey>, TKey> _types;

        #endregion


        #region Constructors

        public TypeSearchQueryHandler(ITypeEntityService<TypeEntityBase<TKey>, TKey> types)
        {
            _types = types ?? throw new ArgumentNullException(nameof(types));
        }

        #endregion


        #region Public Methods

        public Task<Result<Page<TypeEntityBase<TKey>, TKey>>> Handle(TypeSearchQuery<TypeEntityBase<TKey>, TKey> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return _types.SearchAsync(request.Adapt<TypeSearchCriteria>());
        }

        #endregion
    }
}