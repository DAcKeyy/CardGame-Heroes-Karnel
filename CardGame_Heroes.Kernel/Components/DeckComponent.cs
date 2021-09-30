using CardGame_Heroes.Kernel.Cards;
using System.Collections.Generic;

namespace CardGame_Heroes.Kernel.Components
{
    public struct DeckComponent
    {
        public DeckComponent(List<Card> deck)
        {
            Deck = deck;
        }

        public List<Card> Deck {  get; set; }
    }
}
