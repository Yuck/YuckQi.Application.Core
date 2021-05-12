using System;
using MediatR;
using YuckQi.Application.Core.Abstract;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Commands
{
    public class CreateTypeEntityCommand<TTypeEntity, TKey> : IRequest<Result<TTypeEntity>>, ITypeRequest where TTypeEntity : IEntity<TKey>, IType where TKey : struct
    {
        #region Properties

        public Guid? Identifier { get; }
        public String Name { get; }
        public String ShortName { get; }

        #endregion


        #region Constructors

        public CreateTypeEntityCommand(Guid? identifier, String name, String shortName)
        {
            Identifier = identifier;
            Name = name;
            ShortName = shortName;
        }

        #endregion
    }
}