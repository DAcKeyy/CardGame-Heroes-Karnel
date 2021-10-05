using CardGame_Heroes.Kernel.Components;
using System;

namespace CardGame_Heroes.Kernel
{
    public class Game
    {
        public GameECS ECSystem;
        PlayerComponent[] players;

        public Game(PlayerComponent[] playersData)
        {
            players = playersData;

            if (players == null) throw new Exception("There's no player data");
            if (players.Length == 1) throw new Exception("Game requires more than one player");
        }

        public void Start()
        {
            ECSystem = new GameECS(players);
            ECSystem.InitSystems();
        }

        public void Stop()
        {
            ECSystem.DestroySystems();
        }
    }
}
