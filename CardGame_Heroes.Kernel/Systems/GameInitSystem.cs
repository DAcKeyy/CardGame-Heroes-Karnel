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
                addManapoolComponentToEntity(_world.NewEntity(), playerData);

                Logger.WriteLog(new Snapshot($"Player {playerData.Nickname} Entitys assembled"));
            }
        }


        private static void addHandComponentToEntity(EcsEntity handEntity, PlayerData data)
        {
            ref HandComponent handComponent = ref handEntity.Get<HandComponent>();
            handComponent.Cards = new List<Card>();
            Logger.WriteLog(new Snapshot($"{handComponent.GetType().Name} attached to {handEntity} EcsEntity"));

            ref OwnerComponent ownerComponent = ref handEntity.Get<OwnerComponent>();
            ownerComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{ownerComponent.GetType().Name} attached to {handEntity} EcsEntity"));
        }

        private static void addDeckComponentToEntity(EcsEntity deckEntity, PlayerData data)
        {
            ref DeckComponent deckComponent = ref deckEntity.Get<DeckComponent>();
            Logger.WriteLog(new Snapshot($"{deckComponent.GetType().Name} attached to {deckEntity} EcsEntity"));

            ref OwnerComponent ownerComponent = ref deckEntity.Get<OwnerComponent>();
            ownerComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{ownerComponent.GetType().Name} attached to {deckEntity} EcsEntity"));

            deckComponent.Cards = new List<Card>(data.Cards);
            deckComponent.Cards.RemoveAll(card => card.Type == Cards.Enums.CardType.Герой);

            string log = $"Deck is..\n";
            foreach (var card in deckComponent.Cards) log += $"{card.Name}\n";
            Logger.WriteLog(new Snapshot(log));
        }

        private static void addGraveyardComponentToEntity(EcsEntity graveyardEntity, PlayerData data)
        {
            ref GravyardComponent graveyardComponent = ref graveyardEntity.Get<GravyardComponent>();
            graveyardComponent.Cards = new List<Card>();
            Logger.WriteLog(new Snapshot($"{graveyardComponent.GetType().Name} attached to {graveyardEntity} EcsEntity"));

            ref OwnerComponent ownerComponent = ref graveyardEntity.Get<OwnerComponent>();
            ownerComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{ownerComponent.GetType().Name} attached to {graveyardEntity} EcsEntity"));
        }

        private static void addTablesideComponentToEntity(EcsEntity tablesideEntity, PlayerData data)
        {
            ref TablesideComponent tablediseComponent = ref tablesideEntity.Get<TablesideComponent>();
            tablediseComponent.Cards = new List<Card>();
            Logger.WriteLog(new Snapshot($"{tablediseComponent.GetType().Name} attached to {tablesideEntity} EcsEntity"));

            ref OwnerComponent ownerComponent = ref tablesideEntity.Get<OwnerComponent>();
            ownerComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{ownerComponent.GetType().Name} attached to {tablesideEntity} EcsEntity"));
        }

        private static void addHeroComponentToEntity(EcsEntity heroEntity, PlayerData data)
        {
            List<Card> cards = new(data.Cards);

            var heroesCards = cards.FindAll(card => card.Type == Cards.Enums.CardType.Герой);

            if (heroesCards.Count == 0) throw new System.Exception($"В колоде нету карты типа {Cards.Enums.CardType.Герой}");
            if (heroesCards.Count > 1) throw new System.Exception("В колоде больше одного героя");

            ref HeroComponent heroComponent = ref heroEntity.Get<HeroComponent>();
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
            Logger.WriteLog(new Snapshot($"{heroComponent.GetType().Name} attached to {heroEntity} EcsEntity"));

            ref OwnerComponent ownerComponent = ref heroEntity.Get<OwnerComponent>();
            ownerComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{ownerComponent.GetType().Name} attached to {heroEntity} EcsEntity"));
        }

        private static void addPlayerComponentToEntity(EcsEntity playerEntity, PlayerData data)
        {
            ref PlayerStateComponent playerStateComponent = ref playerEntity.Get<PlayerStateComponent>();
            //TODO: addPlayerComponentToEntity 
            //

            Logger.WriteLog(new Snapshot($"{playerStateComponent.GetType().Name} attached to {playerEntity} EcsEntity"));

            ref OwnerComponent ownerComponent = ref playerEntity.Get<OwnerComponent>();
            ownerComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{ownerComponent.GetType().Name} attached to {playerEntity} EcsEntity"));
        }

        private static void addManapoolComponentToEntity(EcsEntity manapoolEntity, PlayerData data)
        {
            ref ManapoolComponent manapoolComponent = ref manapoolEntity.Get<ManapoolComponent>();
            manapoolComponent.Mana = 0;
            Logger.WriteLog(new Snapshot($"{manapoolComponent.GetType().Name} attached to {manapoolEntity} EcsEntity"));

            ref OwnerComponent ownerComponent = ref manapoolEntity.Get<OwnerComponent>();
            ownerComponent.ownerData = data;
            Logger.WriteLog(new Snapshot($"{ownerComponent.GetType().Name} attached to {manapoolEntity} EcsEntity"));
        }
    }
}
