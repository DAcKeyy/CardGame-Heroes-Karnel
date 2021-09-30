using CardGame_Heroes.Kernel.Components;

namespace CardGame_Heroes.Kernel
{
    public class Game
    {
        public GameECS ECSystem;

        public void Start(PlayerComponent[] players)
        {
            ECSystem = new GameECS(players);
            ECSystem.Init();
        }

        public void Stop()
        {
            ECSystem.Destroy();
        }
    }
}
