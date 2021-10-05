using CardGame_Heroes.Kernel.Cards;
using System.Collections.Generic;

namespace CardGame_Heroes.Kernel.Components
{
    public struct DeckComponent : ICardFieldComponent
    {
        public List<Card> Cards { get; set; }
    }
}
