using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Services.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Queries.Handlers;

public class GetTypeEntityQueryHandler<TTypeEntity, TIdentifier> : IRequestHandler<GetTypeEntityQuery<TTypeEntity, TIdentifier>, Result<TTypeEntity>> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : IEquatable<TIdentifier>
{
    private readonly ITypeEntityService<TTypeEntity, TIdentifier> _types;

    public GetTypeEntityQueryHandler(ITypeEntityService<TTypeEntity, TIdentifier> types)
    {
        _types = types ?? throw new ArgumentNullException(nameof(types));
    }

    public Task<Result<TTypeEntity>> Handle(GetTypeEntityQuery<TTypeEntity, TIdentifier> request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        return _types.Get(request.Identifier, cancellationToken);
    }
}
