using CardGame_Heroes.Kernel.Cards;

namespace CardGame_Heroes.Kernel.Components
{
    public struct CreatureComponent
    {
        public CreatureComponent(Card card, int health, int attack)
        {
            Card = card;
            Health = health;
            Attack = attack;
        }

        public Card Card {  get; set; }
        public int Health {  get; set; }
        public int Attack {  get; set; }
    }
}
