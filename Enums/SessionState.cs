using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ayclass_backend.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SessionState
    {
        Pending,
        Closed,
        Accepted,
    }
}