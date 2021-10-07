using CardGame_Heroes.Kernel.Components;
using Leopotam.Ecs;

namespace CardGame_Heroes.Kernel.Systems
{
    public class TimerSystem : IEcsSystem, IEcsRunSystem, IEcsInitSystem
    {
        EcsWorld _world = new();
        EcsFilter<TimerComponent> TablesideSystemFilter = null;

        public void Init()
        {
             _world.NewEntity();
        }

        public void Run()
        {
            foreach(var i in TablesideSystemFilter)
            {
                ref var tablesideComponent = ref TablesideSystemFilter.Get1(i);

                if(tablesideComponent.timer.Enabled == false)
                {
                    var entity = TablesideSystemFilter.GetEntity(i);
                    entity.Destroy();
                }
            }
        }
    }
}
