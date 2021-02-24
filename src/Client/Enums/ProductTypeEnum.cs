using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SalesTaxes.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductTypeEnum
    {
        [EnumMember(Value = "Book")]
        Book = 1,
        [EnumMember(Value = "Food")]
        Food = 2,
        [EnumMember(Value = "Medical")]
        Medical = 3,
        [EnumMember(Value = "Other")]
        Other = 4
    }
}
