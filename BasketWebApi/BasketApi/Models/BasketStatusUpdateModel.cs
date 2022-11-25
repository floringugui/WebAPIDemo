using BasketApi.Models.Enums;
using BasketBL.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace BasketApi.Models
{
    public class BasketStatusUpdateModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public BasketModelStatus Status { get; set; }
    }
}