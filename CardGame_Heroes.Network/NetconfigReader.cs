using System.Text.Json;

namespace CardGame_Heroes.Network
{
    public static class NetconfigReader
    {
        public static NetConfigData ReadConfig()
        {
            using StreamReader r = new(AppDomain.CurrentDomain.BaseDirectory + "netconfig.json");
            return JsonSerializer.Deserialize<NetConfigData>(r.ReadToEnd());
        }

        [Serializable]
        public struct NetConfigData
        {
            public DBData DBdata { get; }
            public RandomOrgData randomOrg { get; }
            public TCPServerData TCPserver {  get; }

            [Serializable]
            public struct DBData
            {
                public string host { get; }
                public string port { get; }
                public string username { get; }
                public string password { get; }
                public string cards_database { get; }
                public string users_database { get; }
                public string matchup_database { get; }
            }

            [Serializable]
            public struct RandomOrgData
            {
                public string apiKey { get; }
            }

            [Serializable]
            public struct TCPServerData
            {
                public int port {  get; }
            }
        }
    }
}
