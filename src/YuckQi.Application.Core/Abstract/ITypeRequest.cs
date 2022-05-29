using System;

namespace YuckQi.Application.Core.Abstract;

public interface ITypeRequest<out TIdentifier>
{
    TIdentifier Identifier { get; }
    String Name { get; }
    String ShortName { get; }
}
