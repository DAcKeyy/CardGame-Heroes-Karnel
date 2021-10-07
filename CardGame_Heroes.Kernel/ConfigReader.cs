using System.Text.Json;
using System.IO;
using System;

namespace CardGame_Heroes.Kernel
{
    public static class ConfigReader
    {
        public static ConfigData ReadConfig()
        {
            using StreamReader r = new("config.json");
                return JsonSerializer.Deserialize<ConfigData>(r.ReadToEnd());
        }

        [Serializable]
        public struct ConfigData
        {
            public Times times {  get; }

            [Serializable]
            public struct Times
            {
                public float mulligan { get; }
                public float playerTurn { get; }
                public float playerTurnMultiplier { get; }
            }
        }
    }
}
