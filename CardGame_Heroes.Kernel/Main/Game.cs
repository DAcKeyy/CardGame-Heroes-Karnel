using CardGame_Heroes.Kernel.Components;
using CardGame_Heroes.Kernel.Logs;
using System;

namespace CardGame_Heroes.Kernel
{
    public class Game
    {
        public GameECS ECSystem;
        readonly PlayerData[] players;

        public Game(PlayerData[] playersData)
        {
            players = playersData;

            if (players == null) throw new Exception("There's no player data");
            if (players.Length < 2) throw new Exception("Game requires unless two players.");
        }

        public void Start()
        {
            Logger.WriteLog(new Snapshot("Game started"));
            
            ECSystem = new GameECS(players);
            ECSystem.InitSystems();
        }

        public void Stop()
        {
            Logger.WriteLog(new Snapshot("ZAAAA WARDOO!!!"));
            ECSystem.DestroySystems();
        }
    }
}
