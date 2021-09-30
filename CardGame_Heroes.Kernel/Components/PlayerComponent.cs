using CardGame_Heroes.Kernel.Cards;

namespace CardGame_Heroes.Kernel.Components
{
    public struct PlayerComponent
    {
        public uint ID;
        public string Nickname;
        public Card[] Cards;

        public PlayerComponent(uint iD, string nickname, Card[] cards)
        {
            ID = iD;
            Nickname = nickname;
            Cards = cards;
        }
    }
}
