using CardGame_Heroes.Kernel.Cards;
using CardGame_Heroes.Kernel.Components;
using CardGame_Heroes.Kernel.Logs;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace CardGame_Heroes.Kernel
{
    public static class PlayerCreator
    {
        public static EcsEntity CreatePlayerEntity(EcsWorld world, uint iD, string nickname, Card[] cards)
        {
            var playerEntity = world.NewEntity();
            Logger.WriteLog(new Snapshot($"Constracting Player {nickname} Entity.."));

            addHandComponent(playerEntity);
            addDeckComponent(playerEntity, cards);
            addGraveyardComponent(playerEntity);
            addTablesideComponent(playerEntity);
            addPlayerinfoComponent(playerEntity, iD, nickname, cards);

            Logger.WriteLog(new Snapshot($"Player {nickname} Entity assembled"));

            return playerEntity;
        }

        private static void addHandComponent(EcsEntity player)
        {
            ref HandComponent playerHand = ref player.Get<HandComponent>();
            playerHand.Cards = new List<Cards.Card>();
            Logger.WriteLog(new Snapshot($"Hand Component attached to Player Entity"));
        }
        private static void addDeckComponent(EcsEntity player, Card[] cards)
        {
            ref DeckComponent playerDeck = ref player.Get<DeckComponent>();

            Logger.WriteLog(new Snapshot($"Deck Component attached to Player Entity"));

            playerDeck.Cards = new List<Cards.Card>(cards);

            Logger.WriteLog(new Snapshot($"Deck is.."));
            foreach (var card in playerDeck.Cards)
                Logger.WriteLog(new Snapshot($"{card.Name}"));
        }
        private static void addGraveyardComponent(EcsEntity player)
        {
            ref GravyardComponent playerGravyard = ref player.Get<GravyardComponent>();
            playerGravyard.Cards = new List<Cards.Card>();
            Logger.WriteLog(new Snapshot($"Graveyard Component attached to Player Entity"));
        }
        private static void addTablesideComponent(EcsEntity player)
        {
            ref TableSideComponent playerSide = ref player.Get<TableSideComponent>();
            playerSide.Cards = new List<Cards.Card>();
            Logger.WriteLog(new Snapshot($"Tableside Component attached to Player Entity"));
        }
        private static void addPlayerinfoComponent(EcsEntity player, uint iD, string nickname, Card[] cards)
        {
            ref PlayerComponent playerData = ref player.Get<PlayerComponent>();
            playerData.ID = iD;
            playerData.Nickname = nickname;
            playerData.Cards = cards;
            Logger.WriteLog(new Snapshot($"Player info [id:{iD}, nick:{nickname}] attached to Player Entity"));
        }
    }
}
