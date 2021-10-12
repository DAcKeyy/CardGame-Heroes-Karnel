using Leopotam.Ecs;
using CardGame_Heroes.Kernel.Components;
using System;

namespace CardGame_Heroes.Kernel.Systems
{
    public class GameStateSystem : IEcsSystem, IEcsPreInitSystem, IEcsInitSystem
    {
        EcsWorld _world = null;
        EcsFilter<GameStateComponent> gameStateSystemFilter;

        public void PreInit()
        {
            var gameStateComponentEntity = _world.NewEntity();
            ref var gameStateComponent = ref gameStateComponentEntity.Get<GameStateComponent>();
            gameStateComponent.State = GameStates.Launched;
        }

        public void Init()
        {
            foreach(var i in gameStateSystemFilter)
            {
                ref var gameStateComponent = ref gameStateSystemFilter.GetEntity(i).Get<GameStateComponent>();
                gameStateComponent.State = GameStates.Mulligan;
                gameStateComponent.stateTimer = new System.Timers.Timer(ConfigReader.ReadConfig().times.mulligan * 1000);
                gameStateComponent.stateTimer.Elapsed += (D, G) => {/*TODO: Timer ended*/ };
            }


            //TODO: Вызов UpdateSystems в GameECS по началу и окончанию
        }

    }
}
