using CardGame_Heroes.Kernel.Cards;
using CardGame_Heroes.Kernel.Components;
using CardGame_Heroes.Kernel.Logs;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace CardGame_Heroes.Kernel.Systems
{
    public class GameInitSystem: IEcsInitSystem, IEcsSystem
    {
        EcsWorld _world = new();
        PlayerData[] _playerDatas;

        public void Init()
        {
            Logger.WriteLog(new Snapshot($"Constracting game Entitys.."));
            foreach (PlayerData playerData in _playerDatas)
            {
                addHandComponent(_world.NewEntity(), playerData);
                addDeckComponent(_world.NewEntity(), playerData);
                addGraveyardComponent(_world.NewEntity(), playerData);
                addTablesideComponent(_world.NewEntity(), playerData);
                addHeroComponent(_world.NewEntity(), playerData);

                Logger.WriteLog(new Snapshot($"Player {playerData.Nickname} Entitys assembled"));
            }
        }


        private static void addHandComponent(EcsEntity hand, PlayerData data)
        {
            ref HandComponent handComponent = ref hand.Get<HandComponent>();
            handComponent.Cards = new List<Cards.Card>();
            Logger.WriteLog(new Snapshot($"Hand Component attached to Hand Entity"));

            ref InherentComponent inherentComponent = ref hand.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"Inherent Component attached to Hand Entity"));
        }

        private static void addDeckComponent(EcsEntity deck, PlayerData data)
        {
            ref DeckComponent _deck = ref deck.Get<DeckComponent>();
            Logger.WriteLog(new Snapshot($"Deck Component attached to Deck Entity"));

            ref InherentComponent inherentComponent = ref deck.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"Inherent Component attached to Deck Entity"));

            _deck.Cards = new List<Cards.Card>(data.Cards);
            _deck.Cards.RemoveAll(card => card.Type == Cards.Enums.CardType.Герой);
            Logger.WriteLog(new Snapshot($"Deck is.."));
            foreach (var card in _deck.Cards)
                Logger.WriteLog(new Snapshot($"{card.Name}"));
        }

        private static void addGraveyardComponent(EcsEntity graveyard, PlayerData data)
        {
            ref GravyardComponent _graveyard = ref graveyard.Get<GravyardComponent>();
            _graveyard.Cards = new List<Cards.Card>();
            Logger.WriteLog(new Snapshot($"Graveyard Component attached to Graveyard Entity"));

            ref InherentComponent inherentComponent = ref graveyard.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"Inherent Component attached to Graveyard Entity"));
        }

        private static void addTablesideComponent(EcsEntity tableside, PlayerData data)
        {
            ref TablesideComponent _tabledise = ref tableside.Get<TablesideComponent>();
            _tabledise.Cards = new List<Cards.Card>();
            Logger.WriteLog(new Snapshot($"Tableside Component attached to Tableside Entity"));

            ref InherentComponent inherentComponent = ref tableside.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"Inherent Component attached to Tableside Entity"));
        }
        private static void addHeroComponent(EcsEntity hero, PlayerData data)
        {
            List<Card> cards = new(data.Cards);

            var heroesCards = cards.FindAll(card => card.Type == Cards.Enums.CardType.Герой);

            if (heroesCards.Count == 0) throw new System.Exception("В колоде нету карты типа \"герой\"");
            if (heroesCards.Count > 1) throw new System.Exception("В колоде больше одного героя");

            ref HeroComponent _hero = ref hero.Get<HeroComponent>();
            _hero.CardInfo = heroesCards[0];
            _hero.Health = (int)_hero.CardInfo.Health;

            _hero.EquippedWeapon = new Card()
            {
                Type = Cards.Enums.CardType.Null
            };
            _hero.EquippedNeckless = new Card()
            {
                Type = Cards.Enums.CardType.Null
            };
            _hero.EquippedArmor = new Card()
            {
                Type = Cards.Enums.CardType.Null
            };
            Logger.WriteLog(new Snapshot($"HeroComponent Component attached to Hero Entity"));

            ref InherentComponent inherentComponent = ref hero.Get<InherentComponent>();
            inherentComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"Inherent Component attached to Hero Entity"));
        }
    }
}
