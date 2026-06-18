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
        
        public string m_Name {  get; set; } = "";
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
            List<CardsObj.CardEntriesObj.Card> CardList = [];
            foreach (CardItem UniqueCard in CardItems.DistinctBy(x => x.ID))
            {
                CardsObj.CardEntriesObj.Card CardForList = new();
                CardForList.Faction = Faction;
                CardForList.Guid = UniqueCard.Guid;
                CardForList.CardGuid = UniqueCard.ID;
                CardForList.NumCopies = CardItems.Count(x => x.ID == UniqueCard.ID);
                CardForList.Filter = "";
                CardList.Add(CardForList);
            }
            Cards = new();
            Cards.CardEntries = new();
            Cards.CardEntries.Array = CardList.ToArray();
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
    internal class EditableDeck
    {
        public List<CardItem> Cards { get; set; } = [];
        public static CardItem GetCardByID(int id)
        {
            if (!CardsStorage.AllCardItems.Exists(x => x.ID == id))
                CardsStorage.AllCardItems.Add(new CardItem(id, "MISSING_CARD_" + id.ToString(), "MISSING_GUID_" + id.ToString()));

            return CardsStorage.AllCardItems.Find(x => x.ID == id)!;
            
       
        }
        public void SetCardsByIDs(int[] IDs)
        {
            Cards = IDs.Order().Select(GetCardByID).ToList();
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