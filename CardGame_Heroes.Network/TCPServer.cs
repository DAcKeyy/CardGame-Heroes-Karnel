using Telepathy;

namespace CardGame_Heroes.Network
{
    public static class TCPServer
    {
        private static int port = NetconfigReader.ReadConfig().TCPserver.port;
        private static Telepathy.Server server = new();

        /// <summary>
        /// Обновить приянтые данные с помощью Server.Tick()
        /// </summary>
        public static void Update()
        {
            if (server.Active == false) return;

        }




        public static void ChangePort(string newPort) =>
            port = Convert.ToInt32(newPort);    
        
        public static void StartServer()
        {
            if (server.Active) throw new Exception("Server is already running");
            server.Start(port);
        }

        public static void StopServer()
        {
            if (server.Active == false) throw new Exception("Server is already stopped");
            server.Stop();
        }
    }
}
