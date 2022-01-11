using System;
using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Queries
{
    public class GetTypeEntityQuery<TTypeEntity, TKey> : IRequest<Result<TTypeEntity>> where TTypeEntity : IEntity<TKey>, IType where TKey : struct
    {
        #region Properties

        public Guid? Identifier { get; }

        #endregion


        #region Constructors

        public GetTypeEntityQuery(Guid? identifier)
        {
            Identifier = identifier;
        }

        #endregion
    }
}
