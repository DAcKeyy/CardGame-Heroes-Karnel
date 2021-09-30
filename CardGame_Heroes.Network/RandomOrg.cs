using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anemonis.RandomOrg;

namespace CardGame_Heroes.Network
{
    public class RandomOrg
    {
        const string randomOrgApiKey = "bd9dbe85-cf02-49d0-aa40-84a793dce0e9";
        public RandomOrgClient randomOrgClient;
        public readonly bool isConnectingToGoogle;

        public RandomOrg()
        {
            var networkChecker = new InternetChecker();
            isConnectingToGoogle = networkChecker.PingGoogleDotCom();
            if (isConnectingToGoogle)
                randomOrgClient = new RandomOrgClient(randomOrgApiKey);
        }
    }
}
