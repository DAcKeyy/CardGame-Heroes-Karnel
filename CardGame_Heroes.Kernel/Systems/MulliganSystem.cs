using Leopotam.Ecs;
using CardGame_Heroes.Kernel.Components;
using System.Collections.Generic;
using System.Linq;  

namespace CardGame_Heroes.Kernel.Systems
{
    public class MulliganSystem : IEcsSystem,  IEcsRunSystem, IEcsInitSystem
    {
        EcsWorld _world = null;
        EcsFilter<PlayerStateComponent> mulliganSystem_Filter_PlayerStateEntitys;
        EcsFilter<DeckComponent, OwnerComponent> mulliganSystem_Filter_DeckEntitys;

        public void Init()
        {
            setPlayerMoveOrders();
            createMulliganEntitys();
        }

        public void Run()
        {
            
        }

        private void setPlayerMoveOrders()
        {
            List<int> movesOrder = 
                new(mulliganSystem_Filter_PlayerStateEntitys.GetEntitiesCount()); //{0,0,0,0}

            for (int i = 1; i < movesOrder.Count + 1; i++)
                movesOrder[i - 1] = i; //{1,2,3,4}

            movesOrder = Random.Randomizer.ShuffleList(movesOrder).Result; //{2,1,4,3}

            foreach (var i in mulliganSystem_Filter_PlayerStateEntitys)
            {
                ref var playerStateComponent = 
                    ref mulliganSystem_Filter_PlayerStateEntitys.GetEntity(i).Get<PlayerStateComponent>();
                playerStateComponent.MoveOrder = movesOrder[i];// = {2},{1},{4},{3}
            }
        }

        private void createMulliganEntitys()
        {
            foreach (var i in mulliganSystem_Filter_DeckEntitys)
            {
                var mulliganEntity = _world.NewEntity();
                ref var MulliganpoolComponent = ref mulliganEntity.Get<MulliganpoolComponent>();
                ref var ownerComponent = ref mulliganEntity.Get<OwnerComponent>();


                ownerComponent.ownerData = 
                    mulliganSystem_Filter_DeckEntitys.GetEntity(i).Get<OwnerComponent>().ownerData;

                MulliganpoolComponent.Pool = 
                    mulliganSystem_Filter_DeckEntitys.GetEntity(i).Get<DeckComponent>().
                    Cards.Take(ConfigReader.ReadConfig().gameParams.mulliganCardsCount).
                    ToList();
            }
        }
    }
}
