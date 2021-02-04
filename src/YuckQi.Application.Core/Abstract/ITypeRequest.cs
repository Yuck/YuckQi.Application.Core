using System;

namespace YuckQi.Application.Core.Abstract
{
    public interface ITypeRequest
    {
        Guid? Identifier { get; }
        string Name { get; }
        string ShortName { get; }
    }
}