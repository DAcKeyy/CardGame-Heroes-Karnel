using CardGame_Heroes.Kernel.Cards;

namespace CardGame_Heroes.Kernel.Components
{
    public struct CardComponent
    {
        public CardComponent(Card card)
        {
            Card = card;
        }

        public Card Card {  get; set; }
    }
}
