using System;
using MediatR;
using YuckQi.Application.Core.Abstract;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Commands;

public class CreateTypeEntityCommand<TTypeEntity, TIdentifier> : IRequest<Result<TTypeEntity>>, ITypeRequest<TIdentifier> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : struct
{
    #region Properties

    public TIdentifier Identifier { get; }
    public String Name { get; }
    public String ShortName { get; }

    #endregion


    #region Constructors

    public CreateTypeEntityCommand(TIdentifier identifier, String name, String shortName)
    {
        Identifier = identifier;
        Name = name;
        ShortName = shortName;
    }

    #endregion
}
