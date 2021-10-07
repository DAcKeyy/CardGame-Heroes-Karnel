using Anemonis.RandomOrg;

namespace CardGame_Heroes.Network
{
    public class RandomOrg
    {
        public RandomOrgClient randomOrgClient;
        public readonly bool isConnectingToGoogle;

        public RandomOrg()
        {
            if (new InternetChecker().PingGoogleDotCom())
                randomOrgClient = new RandomOrgClient(NetconfigReader.ReadConfig().randomOrg.apiKey);
            else throw new Exception("Нету соединения с интерентом");
        }
    }
}
