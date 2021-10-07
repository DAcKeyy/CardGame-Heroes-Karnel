using System.Collections.Generic;
using CardGame_Heroes.Kernel.Cards.Enums;
using System;

namespace CardGame_Heroes.Kernel.Cards
{
    [Serializable]
    public struct Card
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string FalvorText { get; set; }
        public int? Cost { get; set; } 
        public int? Attack { get; set; } 
        public int? Health { get; set; } 
        public CardClass? Class { get; set; } 
        public List<CardElement> Elements { get; set; } 
        public CardRareness? Rareness { get; set; }
        public CardType? Type { get; set; }
        public string AboutURL { get; set; }
        public string FaceURL { get; set; }
        public string BorderPath { get; set; }
        public string ImageURL { get; set; }
        public string ImagePath { get; set; }
        public uint? Number_in_Pack  { get; set; }
        public uint? Pack_Cards_Amount { get; set; }
        public string Pack_Name { get; set; }
        public string Artist { get; set; }
    }
}
