using Leopotam.Ecs;
using CardGame_Heroes.Kernel.Components;

namespace CardGame_Heroes.Kernel.Systems
{
    public class TablesideSystem : IEcsSystem, IEcsRunSystem
    {


        EcsFilter<TablesideComponent> TablesideSystemFilter;
        public void Run()
        {
            foreach(var i in TablesideSystemFilter)
            {

            }
        }
    }
}
