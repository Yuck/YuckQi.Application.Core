using System;
using YuckQi.Application.Core.Abstract;
using YuckQi.Application.Core.Queries.Abstract;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;

namespace YuckQi.Application.Core.Queries;

public class SearchTypeEntityQuery<TTypeEntity, TIdentifier> : SearchQueryBase<TTypeEntity>, ITypeRequest<TIdentifier> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : IEquatable<TIdentifier>
{
    public TIdentifier Identifier { get; }
    public String Name { get; }
    public String ShortName { get; }

    public SearchTypeEntityQuery(TIdentifier identifier, String name, String shortName, Int32 number, Int32 size) : base(number, size)
    {
        Identifier = identifier;
        Name = name;
        ShortName = shortName;
    }
}
