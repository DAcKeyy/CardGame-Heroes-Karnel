using CardGame_Heroes.Kernel.Cards;
using System.Collections.Generic;
using System.Linq;

namespace CardGame_Heroes.Kernel.Components
{
    public struct DeckComponent : ICardFieldComponent
    {
        public List<Card> Cards { get; set; }

        public void ShuffleCard(Card card) => 
            Cards.Insert(Random.Randomizer.RandomInt(0, Cards.Count).Result, card);
    }
}
