using System;

namespace YuckQi.Application.Core.Abstract
{
    public interface ITypeRequest
    {
        Guid? Identifier { get; }
        String Name { get; }
        String ShortName { get; }
    }
}
