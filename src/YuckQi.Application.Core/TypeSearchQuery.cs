using YuckQi.Application.Core.Abstract;
using YuckQi.Domain.Entities.Types;

namespace YuckQi.Application.Core
{
    public class TypeSearchQuery<TEntity, TKey> : SearchQueryBase<TEntity, TKey> where TEntity : TypeEntityBase<TKey> where TKey : struct
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}