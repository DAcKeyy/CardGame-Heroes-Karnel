using Leopotam.Ecs;


namespace CardGame_Heroes.Kernel.Systems
{
    public class CommandSystem : IEcsSystem, IEcsInitSystem, IEcsPreInitSystem
    {
        EcsWorld _world = new();

        public void PreInit()
        {

        }

        public void Init()
        {
            
        }
    }
}
