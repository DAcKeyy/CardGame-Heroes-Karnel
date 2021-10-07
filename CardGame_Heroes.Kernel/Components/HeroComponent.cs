using CardGame_Heroes.Kernel.Cards;
using System;

namespace CardGame_Heroes.Kernel.Components
{
    public struct HeroComponent
    {
        public Card CardInfo {  get; set; }
        public int Health {  get; set; }
        public Card EquippedNeckless
        {
            get => equippedNeckless;
            set => equippedNeckless = value.Type == Cards.Enums.CardType.Ожерелье || value.Type == Cards.Enums.CardType.Null
                    ? value
                    : throw new Exception("Trying to add a card of a different type instead of a necklace.");
        }
        public Card EquippedWeapon
        {
            get => equippedWeapon;
            set => equippedWeapon = value.Type == Cards.Enums.CardType.Оружие || value.Type == Cards.Enums.CardType.Null
                    ? value
                    : throw new Exception("Trying to add a card of a different type instead of a weapon.");
        }
        public Card EquippedArmor
        {
            get => equippedArmor;
            set => equippedArmor = value.Type == Cards.Enums.CardType.Броня || value.Type == Cards.Enums.CardType.Null
                    ? value
                    : throw new Exception("Trying to add a card of a different type instead of a armor.");
        }

        private Card equippedNeckless;
        private Card equippedWeapon;
        private Card equippedArmor;
    }
}
