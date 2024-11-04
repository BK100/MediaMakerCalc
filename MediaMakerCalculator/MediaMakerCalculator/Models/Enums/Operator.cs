using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MediaMakerCalculator.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Operator
    {
        Add = 1,
        Subtract = 2,
        Multiply = 3,
        Divide = 4
    }
}
