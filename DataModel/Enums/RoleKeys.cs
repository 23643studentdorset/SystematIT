using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace DataModel.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoleKeys
    {
        [EnumMember(Value = "Admin")]
        Admin = 1,

        [EnumMember(Value = "Manager")]
        Manager = 2,

        [EnumMember(Value = "Regular")]
        Regular = 3
    }
}
