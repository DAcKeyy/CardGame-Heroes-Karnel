using CardGame_Heroes.Kernel.Components;
using System.Collections.Generic;
using Leopotam.Ecs;

namespace CardGame_Heroes.Kernel
{
    public class GameECS : IEcsInitSystem
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

        public void Init()
        {
            for (int iterator = 0; iterator < playersData.Length; iterator++)
            {
                Players[iterator] = 
                    PlayerCreator.CreatePlayerEntity(_world, 
                    playersData[iterator].ID, 
                    playersData[iterator].Nickname, 
                    playersData[iterator].Cards);       
            }
        }

        public void UpdateLoop()
        {
            _systems?.Run();
        }

        public void Destroy()
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
