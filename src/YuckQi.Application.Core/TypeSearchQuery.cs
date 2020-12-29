using YuckQi.Application.Core.Abstract;
using YuckQi.Domain.Entities.Types.Abstract;

namespace YuckQi.Application.Core
{
    public class TypeSearchQuery<TEntity, TKey> : SearchQueryBase<TEntity, TKey> where TEntity : TypeEntityBase<TKey> where TKey : struct
    {
        #region Properties

        public string Code { get; set; }
        public string Name { get; set; }

        #endregion


        #region Constructors

        public TypeSearchQuery(int number, int size) : base(number, size)
        {
        }

        #endregion
    }
}