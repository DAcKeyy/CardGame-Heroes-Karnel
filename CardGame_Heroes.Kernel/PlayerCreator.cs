using CardGame_Heroes.Kernel.Cards;
using CardGame_Heroes.Kernel.Components;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace CardGame_Heroes.Kernel
{
    public static class PlayerCreator
    {
        public static EcsEntity CreatePlayerEntity(EcsWorld world, uint iD, string nickname, Card[] cards)
        {
            var playerEntity = world.NewEntity();

            addHandComponent(playerEntity);
            addDeckComponent(playerEntity, cards);
            addGraveyardComponent(playerEntity);
            addTablesideComponent(playerEntity);
            addPlayerinfoComponent(playerEntity, iD, nickname, cards);

            return playerEntity;
        }

        private static void addHandComponent(EcsEntity player)
        {
            ref HandComponent playerHand = ref player.Get<HandComponent>();
            playerHand.Cards = new List<Cards.Card>();
        }
        private static void addDeckComponent(EcsEntity player, Card[] cards)
        {
            ref DeckComponent playerDeck = ref player.Get<DeckComponent>();
            playerDeck.Cards = new List<Cards.Card>(cards);
        }
        private static void addGraveyardComponent(EcsEntity player)
        {
            ref GravyardComponent playerGravyard = ref player.Get<GravyardComponent>();
            playerGravyard.Cards = new List<Cards.Card>();
        }
        private static void addTablesideComponent(EcsEntity player)
        {
            ref TableSideComponent playerSide = ref player.Get<TableSideComponent>();
            playerSide.Cards = new List<Cards.Card>();
        }
        private static void addPlayerinfoComponent(EcsEntity player, uint iD, string nickname, Card[] cards)
        {
            ref PlayerComponent playerData = ref player.Get<PlayerComponent>();
            playerData.ID = iD;
            playerData.Nickname = nickname;
            playerData.Cards = cards;
        }
    }
}
