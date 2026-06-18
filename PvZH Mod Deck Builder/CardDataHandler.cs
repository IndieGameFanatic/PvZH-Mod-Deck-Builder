using System;
using System.Collections.Generic;
using System.Text;

namespace PvZH_Mod_Deck_Builder
{
    internal class CardDataHandler
    {
        public static Dictionary<string, CardData> LoadedCardData { get; set; } = [];
        public struct CardData
        {
            public string prefabName { get; set; } = "";
            public CardData()
            {

            }
        }
    }
}
