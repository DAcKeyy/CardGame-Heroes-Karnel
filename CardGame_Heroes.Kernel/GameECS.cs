using CardGame_Heroes.Kernel.Components;
using Leopotam.Ecs;
using CardGame_Heroes.Kernel.Logs;

namespace CardGame_Heroes.Kernel
{
    public class GameECS
    {
        public EcsWorld _world;
        public EcsSystems _systems;
        public EcsEntity[] Players;
        private PlayerComponent[] playersData { get; }

        public GameECS(PlayerComponent[] playersData)
        {
            this.playersData = playersData;
            Players = new EcsEntity[playersData.Length];
        }

        public void InitSystems()
        {
            Logger.WriteLog(new Snapshot($"Initiate Systems.."));

            for (int iterator = 0; iterator < playersData.Length; iterator++)
                Players[iterator] =  PlayerCreator.CreatePlayerEntity(_world, 
                                            playersData[iterator].ID, 
                                            playersData[iterator].Nickname, 
                                            playersData[iterator].Cards);       
            


        }

        public void UpdateSystems()
        {
            _systems?.Run();
        }

        public void DestroySystems()
        {
            if(_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}
