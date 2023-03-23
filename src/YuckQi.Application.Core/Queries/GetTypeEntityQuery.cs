using System;
using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Queries;

public class GetTypeEntityQuery<TTypeEntity, TIdentifier> : IRequest<Result<TTypeEntity>> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : IEquatable<TIdentifier>
{
    public TIdentifier Identifier { get; }

    public GetTypeEntityQuery(TIdentifier identifier)
    {
        Identifier = identifier;
    }
}
