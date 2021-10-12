using CardGame_Heroes.Kernel.Components;
using CardGame_Heroes.Kernel.Systems;
using Leopotam.Ecs;
using CardGame_Heroes.Kernel.Logs;

namespace CardGame_Heroes.Kernel
{
    public class GameECS
    {
        public EcsWorld world;
        public EcsSystems systems;

        public EcsEntity[] Players;
        private PlayerData[] playersData { get; }

        public GameECS(PlayerData[] playersData)
        {
            this.playersData = playersData;
        }

        public void InitSystems()
        {
            Logger.WriteLog(new Snapshot($"Initiate Systems.."));

            var systems = new EcsSystems(world);

            systems.Add(new GameInitSystem()).Inject(playersData);
            systems.Add(new MulliganSystem()).Inject(playersData);
            systems.Add(new TablesideSystem());

            systems.Init();
        }

        public void UpdateSystems()
        {
            systems?.Run();
        }

        public void DestroySystems()
        {
            if(systems != null)
            {
                systems.Destroy();
                systems = null;
                world.Destroy();
                world = null;
            }
        }
    }
}
