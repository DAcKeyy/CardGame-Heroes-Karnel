using CardGame_Heroes.Kernel.Cards;
using CardGame_Heroes.Kernel.Components;
using CardGame_Heroes.Kernel.Logs;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace CardGame_Heroes.Kernel.Systems
{
    public class GameInitSystem: IEcsSystem, IEcsPreInitSystem
    {
        EcsWorld _world = new();
        PlayerData[] _playerDatas;

        public void PreInit()
        {
            Logger.WriteLog(new Snapshot($"Constracting game Entitys.."));

            foreach (PlayerData playerData in _playerDatas)
            {
                addHandComponentToEntity(_world.NewEntity(), playerData);
                addDeckComponentToEntity(_world.NewEntity(), playerData);
                addGraveyardComponentToEntity(_world.NewEntity(), playerData);
                addTablesideComponentToEntity(_world.NewEntity(), playerData);
                addHeroComponentToEntity(_world.NewEntity(), playerData);
                addPlayerComponentToEntity(_world.NewEntity(), playerData);

                Logger.WriteLog(new Snapshot($"Player {playerData.Nickname} Entitys assembled"));
            }
        }


        private static void addHandComponentToEntity(EcsEntity hand, PlayerData data)
        {
            ref HandComponent handComponent = ref hand.Get<HandComponent>();
            handComponent.Cards = new List<Card>();
            Logger.WriteLog(new Snapshot($"{handComponent.GetType().Name} attached to {hand} EcsEntity"));

            ref InherentComponent inherentComponent = ref hand.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{inherentComponent.GetType().Name} attached to {hand} EcsEntity"));
        }

        private static void addDeckComponentToEntity(EcsEntity deck, PlayerData data)
        {
            ref DeckComponent deckComponent = ref deck.Get<DeckComponent>();
            Logger.WriteLog(new Snapshot($"{deckComponent.GetType().Name} attached to {deck} EcsEntity"));

            ref InherentComponent inherentComponent = ref deck.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{inherentComponent.GetType().Name} attached to {deck} EcsEntity"));

            deckComponent.Cards = new List<Cards.Card>(data.Cards);
            deckComponent.Cards.RemoveAll(card => card.Type == Cards.Enums.CardType.Герой);
            Logger.WriteLog(new Snapshot($"Deck is.."));
            foreach (var card in deckComponent.Cards)
                Logger.WriteLog(new Snapshot($"{card.Name}"));
        }

        private static void addGraveyardComponentToEntity(EcsEntity graveyard, PlayerData data)
        {
            ref GravyardComponent graveyardComponent = ref graveyard.Get<GravyardComponent>();
            graveyardComponent.Cards = new List<Cards.Card>();
            Logger.WriteLog(new Snapshot($"{graveyardComponent.GetType().Name} attached to {graveyard} EcsEntity"));

            ref InherentComponent inherentComponent = ref graveyard.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{inherentComponent.GetType().Name} attached to {graveyard} EcsEntity"));
        }

        private static void addTablesideComponentToEntity(EcsEntity tableside, PlayerData data)
        {
            ref TablesideComponent tablediseComponent = ref tableside.Get<TablesideComponent>();
            tablediseComponent.Cards = new List<Cards.Card>();
            Logger.WriteLog(new Snapshot($"{tablediseComponent.GetType().Name} attached to {tableside} EcsEntity"));

            ref InherentComponent inherentComponent = ref tableside.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{inherentComponent.GetType().Name} attached to {tableside} EcsEntity"));
        }

        private static void addHeroComponentToEntity(EcsEntity hero, PlayerData data)
        {
            List<Card> cards = new(data.Cards);

            var heroesCards = cards.FindAll(card => card.Type == Cards.Enums.CardType.Герой);

            if (heroesCards.Count == 0) throw new System.Exception($"В колоде нету карты типа {Cards.Enums.CardType.Герой}");
            if (heroesCards.Count > 1) throw new System.Exception("В колоде больше одного героя");

            ref HeroComponent heroComponent = ref hero.Get<HeroComponent>();
            heroComponent.CardInfo = heroesCards[0];
            heroComponent.Health = (int)heroComponent.CardInfo.Health;

            heroComponent.EquippedWeapon = new Card()
            {
                Type = Cards.Enums.CardType.Null
            };
            heroComponent.EquippedNeckless = new Card()
            {
                Type = Cards.Enums.CardType.Null
            };
            heroComponent.EquippedArmor = new Card()
            {
                Type = Cards.Enums.CardType.Null
            };
            Logger.WriteLog(new Snapshot($"{heroComponent.GetType().Name} attached to {hero} EcsEntity"));

            ref InherentComponent inherentComponent = ref hero.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{inherentComponent.GetType().Name} attached to {hero} EcsEntity"));
        }

        private static void addPlayerComponentToEntity(EcsEntity player, PlayerData data)
        {
            ref PlayerStateComponent tablediseComponent = ref player.Get<PlayerStateComponent>();
            //_tabledise.Cards = new List<Cards.Card>();
            Logger.WriteLog(new Snapshot($"{tablediseComponent.GetType().Name} attached to {player} EcsEntity"));

            ref InherentComponent inherentComponent = ref player.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{inherentComponent.GetType().Name} attached to {player} EcsEntity"));
        }
    }
}
