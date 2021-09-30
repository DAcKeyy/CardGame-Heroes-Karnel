using CardGame_Heroes.Kernel.Cards;
using System.Collections.Generic;

namespace CardGame_Heroes.Kernel.Components
{
    public struct TableSideComponent
    {
        public TableSideComponent(List<Card> cards)
        {
            Cards = cards;
        }

        public List<Card> Cards { get; set; }
    }
}
