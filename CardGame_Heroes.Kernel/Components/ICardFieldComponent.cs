using CardGame_Heroes.Kernel.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_Heroes.Kernel.Components
{
    public interface ICardFieldComponent
    {
        public List<Card> Cards { get; set; }
    }
}
