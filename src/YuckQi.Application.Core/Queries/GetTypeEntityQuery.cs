using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Queries;

public class GetTypeEntityQuery<TTypeEntity, TIdentifier> : IRequest<Result<TTypeEntity>> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : struct
{
    #region Properties

    public TIdentifier Identifier { get; }

    #endregion


    #region Constructors

    public GetTypeEntityQuery(TIdentifier identifier)
    {
        Identifier = identifier;
    }

    #endregion
}
