using System.Text.Json;
namespace PvZH_Mod_Deck_Builder
{
    internal class JsonAIDeck
    {
        public string DeckName { get; set; } = "";
        public int[] MainDeckCardIds { get; set; } = [];
        public int[] SuperpowerOverrideCardIds { get; set; } = [];
    }
    internal class JsonStrategyDeck
    {
        public CardsObj Cards { get; set; } = new();
        public int Faction { get; set; }

        public string m_Name { get; set; } = "";
        internal class CardsObj
        {
            public CardEntriesObj CardEntries { get; set; } = new();
            internal class CardEntriesObj
            {
                public Card[] Array { get; set; } = [];
                internal class Card
                {
                    public int Faction { get; set; }
                    public int CardGuid { get; set; }
                    public string Guid { get; set; } = "";
                    public int NumCopies { get; set; }
                    public string Filter { get; set; } = "";
                }
            }
        }
        public int[] AllCardIDs()
        {
            return Cards.CardEntries.Array.SelectMany(card => Enumerable.Repeat(card.CardGuid, card.NumCopies)).ToArray();
        }
        internal string GetCompleteJson(List<CardItem> CardItems)
        {
            Cards = new();
            Cards.CardEntries.Array = CardItems.GroupBy(card => card.ID).Select(group =>
            {
                CardItem card = group.First();
                return new CardsObj.CardEntriesObj.Card
                {
                    Faction = Faction,
                    Guid = card.Guid,
                    CardGuid = card.ID,
                    NumCopies = group.Count(),
                    Filter = ""
                };
            }).ToArray();
            return JsonSerializer.Serialize(new
            {
                m_GameObject = new { m_FileID = 0, m_PathID = 0 },
                m_Enabled = 1,
                m_Script = new { m_FileID = 0, m_PathID = 7190961916729645371 },
                m_Name,
                Faction,
                Cards,
                SuperpowerOverrides = new { CardEntries = new { Array = Array.Empty<object>() } }
            }, new JsonSerializerOptions { WriteIndented = true });
        }
    }
    public struct CardItem
    {
        public string Name { get; set; } = "";
        public int ID { get; set; } = -1;
        public string Guid { get; set; } = "";
        public CardItem(int id, string name, string guid)
        {
            Guid = guid;
            ID = id;
            if (name.Contains("--")) Name = guid;
            else Name = name;
        }
    }
}
