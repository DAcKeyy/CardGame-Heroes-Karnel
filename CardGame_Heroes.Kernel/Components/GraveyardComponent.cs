using CardGame_Heroes.Kernel.Cards;
using System.Collections.Generic;

namespace CardGame_Heroes.Kernel.Components
{
    public struct GravyardComponent
    {
        public GravyardComponent(List<Card> gravyard)
        {
            Gravyard = gravyard;
        }

        public List<Card> Gravyard { get; set; }
    }
}
