using CardGame_Heroes.Kernel.Cards;
using System.Collections.Generic;

namespace CardGame_Heroes.Kernel.Components
{
    public struct HandComponent
    {
        public HandComponent(List<Card> hand)
        {
            Hand = hand;
        }

        public List<Card> Hand {  get; set; }   
    }
}
