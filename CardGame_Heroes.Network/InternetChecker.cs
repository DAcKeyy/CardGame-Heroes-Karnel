using System.Net.NetworkInformation;

namespace CardGame_Heroes.Network
{
    public class InternetChecker
    {
        public bool PingGoogleDotCom()
        {
            return IsConnectedToInternet("https://www.google.com/");
        }

        static bool IsConnectedToInternet(string host)
        {
            bool result = false;
            Ping p = new();

            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            return result;
        }
    }
}
