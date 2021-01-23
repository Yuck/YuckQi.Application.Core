using System;
using YuckQi.Application.Core.Abstract;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Application.Core.Queries
{
    public class TypeEntitySearchQuery<TTypeEntity, TKey> : SearchQueryBase<TTypeEntity> where TTypeEntity : IEntity<TKey>, IType where TKey : struct
    {
        #region Properties

        public Guid? Identifier { get; }
        public string Name { get; }
        public string ShortName { get; }

        #endregion


        #region Constructors

        public TypeEntitySearchQuery(Guid? identifier, string name, string shortName, int number, int size) : base(number, size)
        {
            Identifier = identifier;
            Name = name;
            ShortName = shortName;
        }

        #endregion
    }
}