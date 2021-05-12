using System;

namespace YuckQi.Application.Core
{
    // TODO: Where should this really go? Maybe a folder/namespace for Extensions/Serialization (or Serialization/Extensions)?
    public static class ObjectExtensions // TODO: Name this ObjectSerializerExtensions?
        // But should this contain only JSON or also XML? Probably just JSON, and then name it Serialization/Json/Extensions perhaps
    {
        public static String ToJson<T>(T thing) => throw new NotImplementedException();
    }
}