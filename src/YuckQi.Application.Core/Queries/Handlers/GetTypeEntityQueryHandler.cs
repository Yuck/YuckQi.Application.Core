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
        private readonly ITypeEntityService<TTypeEntity, TKey> _components;

        public GetTypeEntityQueryHandler(ITypeEntityService<TTypeEntity, TKey> components)
        {
            _components = components ?? throw new ArgumentNullException(nameof(components));
        }

        public Task<Result<TTypeEntity>> Handle(GetTypeEntityQuery<TTypeEntity, TKey> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Identifier == null)
                throw new ArgumentNullException(nameof(request.Identifier));

            return _components.GetAsync(request.Identifier.Value);
        }
    }
}