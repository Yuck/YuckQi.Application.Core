using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Services.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Queries.Handlers
{
    public class GetTypeEntityQueryHandler<TTypeEntity, TKey> : IRequestHandler<GetTypeEntityQuery<TTypeEntity, TKey>, Result<TTypeEntity>> where TTypeEntity : IEntity<TKey>, IType where TKey : struct
    {
        #region Private Members

        private readonly ITypeEntityService<TTypeEntity, TKey> _types;

        #endregion


        #region Constructors

        public GetTypeEntityQueryHandler(ITypeEntityService<TTypeEntity, TKey> types)
        {
            _types = types ?? throw new ArgumentNullException(nameof(types));
        }

        #endregion


        #region Public Methods

        public Task<Result<TTypeEntity>> Handle(GetTypeEntityQuery<TTypeEntity, TKey> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Identifier == null)
                throw new ArgumentNullException(nameof(request.Identifier));

            return _types.GetAsync(request.Identifier.Value);
        }

        #endregion
    }
}
