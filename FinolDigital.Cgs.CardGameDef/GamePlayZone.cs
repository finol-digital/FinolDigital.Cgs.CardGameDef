namespace FinolDigital.Cgs.CardGameDef
{
    using Newtonsoft.Json;
    using System.ComponentModel;

    [JsonObject(MemberSerialization.OptIn)]
    public class GamePlayZone
    {
        [JsonProperty]
        [Description("When a Card enters the Game Play Zone, the Card will display this face")]
        [DefaultValue("any")]
        public FacePreference Face { get; private set; } = FacePreference.Any;

        [JsonProperty]
        [Description("Indicates the Game Play Zone's position in inches")]
        public Float2 Position { get; private set; }

        [JsonProperty]
        [Description("Indicates the Game Play Zone's width and height in inches")]
        public Float2 Size { get; private set; }

        [JsonProperty]
        [Description("The Game Play Zone type from area, horizontal, or vertical")]
        [DefaultValue("area")]
        public GamePlayZoneType Type { get; private set; } = GamePlayZoneType.Area;

        [JsonConstructor]
        public GamePlayZone(FacePreference face, Float2 position, Float2 size, GamePlayZoneType type)
        {
            Face = face;
            Position = position;
            Size = size;
            Type = type;
        }
    }
}