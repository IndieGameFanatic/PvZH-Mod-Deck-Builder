using System.ComponentModel;
using System.Text.Json;
namespace PvZH_Mod_Deck_Builder
{
    internal class JsonAIDeck
    {
        public string DeckName { get; set; } = "";
        public int[] MainDeckCardIds { get; set; }
        public int[] SuperpowerOverrideCardIds { get; set; } = [];
    }
    internal class JsonStrategyDeck
    {
        public CardsObj Cards { get; set; }
        public int Faction { get; set; }
        
        public string m_Name {  get; set; }
        internal class CardsObj
        {
            public CardEntriesObj CardEntries { get; set; }
            internal class CardEntriesObj
            {
                public Card[] Array { get; set; }
                internal class Card
                {
                    public int Faction { get; set; }
                    public int CardGuid { get; set; }
                    public string Guid { get; set; }
                    public int NumCopies { get; set; }
                    public string Filter { get; set; }
                }
            }
        }
        public int[] AllCardIDs()
        {
            List<int> CardIDs = [];
            foreach (CardsObj.CardEntriesObj.Card Card in Cards.CardEntries.Array)
            {
                for (int i = 0; i < Card.NumCopies; i++) CardIDs.Add(Card.CardGuid);
            }
            return CardIDs.ToArray();
        }
        internal string GetCompleteJson(List<CardItem> CardItems)
        {
            List<CardItem> UniqueCards = CardItems.DistinctBy(x => x.ID).ToList();
            List<CardsObj.CardEntriesObj.Card> CardList = [];
            foreach (CardItem UniqueCard in UniqueCards)
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
            string str =
                """
                {
                  "m_GameObject": {
                    "m_FileID": 0,
                    "m_PathID": 0
                  },
                  "m_Enabled": 1,
                  "m_Script": {
                    "m_FileID": 0,
                    "m_PathID": 7190961916729645371
                  },
                  "m_Name": "REPLACE_NAME",
                  "Faction": "REPLACE_FACTION",
                  "Cards": {
                    "CardEntries": {
                      "Array": "REPLACE_ARRAY"
                    }
                  },
                  "SuperpowerOverrides": {
                    "CardEntries": {
                      "Array": []
                    }
                  }
                }
                """;
            str = str.Replace("\"REPLACE_FACTION\"", Faction.ToString());
            str = str.Replace("\"REPLACE_NAME\"", $"\"{m_Name}\"");
            str = str.Replace("\"REPLACE_ARRAY\"", JsonSerializer.Serialize(Cards.CardEntries.Array));
            return str;
        }
    }
    internal class EditableDeck
    {
        public List<CardItem> Cards { get; set; } = [];
        public int[] GetCardsAsIDs()
        {
            List<int> IDs = [];
            foreach (CardItem Card in Cards)
            {
                IDs.Add(Card.ID);
            }
            return IDs.ToArray();
        }
        public List<CardItem> UniqueCards()
        {
            return Cards.DistinctBy(x => x.ID).ToList();
        }
        public int CopiesOfCard(CardItem Card)
        {
            int count = Cards.Count(x => x.ID == Card.ID);
            return count;
        }
        public static CardItem GetCardByID(int id)
        {
            if (!CardsStorage.AllCardItems.Exists(x => x.ID == id))
                CardsStorage.AllCardItems.Add(new CardItem(id, "MISSING_CARD_" + id.ToString(), "MISSING_GUID_" + id.ToString()));

            return CardsStorage.AllCardItems.Find(x => x.ID == id);
            
       
        }
        public void AddCardByID(int id)
        {
            Cards.Add(GetCardByID(id));
        }
        public void SetCardsByIDs(int[] IDs)
        {
            Cards.Clear();
            IDs.Sort();
            foreach (int id in IDs)
            {
                AddCardByID(id);
            }
        }
        List<CardItem> StoredUniqueCards = [];

        public void ForceUniqueCardsUpdate()
        {
            StoredUniqueCards.Clear();
        }

        public bool UniqueCardsUpdated()
        {
            bool UCC = UniqueCardsChanged();
            if (UCC) 
            {
                StoredUniqueCards.Clear();

                foreach (CardItem Card in UniqueCards()) 
                    StoredUniqueCards.Add(Card); 
            }
            return UCC;
        }
        bool UniqueCardsChanged()
        {
            if (StoredUniqueCards.Count < 1) return true;

            if (UniqueCards().Count != StoredUniqueCards.Count) return true;

            foreach (CardItem Card in StoredUniqueCards)
                if (!UniqueCards().Exists(x => x.ID == Card.ID)) return true;

            return false;
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