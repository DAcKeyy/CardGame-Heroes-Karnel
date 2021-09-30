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
                Players[iterator] = _world.NewEntity();

                ref DeckComponent playerDeck = ref Players[iterator].Get<DeckComponent>();
                playerDeck.Deck = new List<Cards.Card>(playersData[iterator].Cards);

                ref TableSideComponent playerSide = ref Players[iterator].Get<TableSideComponent>();
                playerSide.Cards = new List<Cards.Card>();

                ref GravyardComponent playerGravyard = ref Players[iterator].Get<GravyardComponent>();
                playerGravyard.Gravyard = new List<Cards.Card>();

                ref HandComponent playerHand = ref Players[iterator].Get<HandComponent>();
                playerHand.Hand = new List<Cards.Card>();

                ref PlayerComponent playerData = ref Players[iterator].Get<PlayerComponent>();
                playerData.ID = playersData[iterator].ID;
                playerData.Nickname = playersData[iterator].Nickname;
                playerData.Cards = playersData[iterator].Cards;                
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
