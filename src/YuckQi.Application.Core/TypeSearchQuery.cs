using System;
using YuckQi.Application.Core.Abstract;
using YuckQi.Domain.Entities.Types.Abstract;

namespace YuckQi.Application.Core
{
    public class TypeSearchQuery<TKey> : SearchQueryBase<ITypeEntity<TKey>, TKey> where TKey : struct
    {
        #region Properties

        public Guid? Identifier { get; }
        public string Name { get; }

        #endregion


        #region Constructors

        public TypeSearchQuery(Guid? identifier, string name, int number, int size) : base(number, size)
        {
            Identifier = identifier;
            Name = name;
        }

        #endregion
    }
}