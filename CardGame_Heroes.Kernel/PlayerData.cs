using CardGame_Heroes.Kernel.Cards;

namespace CardGame_Heroes.Kernel.Components
{
    public struct PlayerData
    {
        public uint ID;
        public string Nickname;
        public Card[] Cards;

        public PlayerData(uint iD, string nickname, Card[] cards)
        {
            ID = iD;
            Nickname = nickname;
            Cards = cards;
        }
    }
}
