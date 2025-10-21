using System;
using System.Text.Json.Serialization;

namespace Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum RpgClass{
        Beginner = 0,
        Warrior = 1,
        Magician = 2,
        Bowman = 3,
        Thief = 4,
        Pirate = 5
    }
}
