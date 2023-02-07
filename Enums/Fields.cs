using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ayclass_backend.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Fields
    {
        Informatique,
        Mathematique,
        Biologie,
        Chimie,
        // to be completed later
    }
}