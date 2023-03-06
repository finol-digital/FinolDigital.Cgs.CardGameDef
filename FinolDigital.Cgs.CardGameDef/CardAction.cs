namespace FinolDigital.Cgs.CardGameDef
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardAction
    {
        [EnumMember(Value = "move")] Move,
        [EnumMember(Value = "flip")] Flip,
        [EnumMember(Value = "rotate")] Rotate,
        [EnumMember(Value = "tap")] Tap,
        [EnumMember(Value = "zoom")] Zoom
    }
}
