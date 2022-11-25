using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.Design;

namespace BasketApi.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BasketModelStatus
    {
        Active,
        Closed
    }
}