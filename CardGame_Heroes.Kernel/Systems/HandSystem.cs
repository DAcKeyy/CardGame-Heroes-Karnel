using Leopotam.Ecs;
using CardGame_Heroes.Kernel.Components;

namespace CardGame_Heroes.Kernel.Systems
{
    public class HandSystem : IEcsRunSystem, IEcsSystem
    {
        EcsWorld _world = null;
        EcsFilter<HandComponent> ecsFilterHandsEntitys;

        public void Run()
        {
            foreach(var i in ecsFilterHandsEntitys)
            {

            }
        }
    }
}
