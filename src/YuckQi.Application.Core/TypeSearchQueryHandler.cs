using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using YuckQi.Domain.Entities.Types.Abstract;
using YuckQi.Domain.Services.Abstract;
using YuckQi.Domain.Services.Models;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects;

namespace YuckQi.Application.Core
{
    public class TypeSearchQueryHandler<TKey> : IRequestHandler<TypeSearchQuery<TypeEntityBase<TKey>, TKey>, Result<Page<TypeEntityBase<TKey>>>> where TKey : struct
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

        public Task<Result<Page<TypeEntityBase<TKey>>>> Handle(TypeSearchQuery<TypeEntityBase<TKey>, TKey> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return _types.SearchAsync(request.Adapt<TypeSearchCriteria>());
        }

        #endregion
    }
}