using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace PvZH_Mod_Deck_Builder
{
    public partial class Form1 : Form
    {
        // TODO: Make pages for DeckList and CardList
        JsonAIDeck AIDeckInfo;
        JsonStrategyDeck StrategyDeckInfo;
        EditableDeck Deck = new();
        public BindingList<CardItem> CurrentCardItems = [];
        List<CardItem> SearchedCards = [];
        int SelectedListCardID = -1;
        int SelectedDeckCardID = -1;
        int CurrentSearchListPage = 0;
        int CurrentDeckListPage = 0;
        int ItemsPerPage = 20;
        public Form1()
        {
            InitializeComponent();
            InitializeAllCards();
            InitializeDeck();
            InitializeCombos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeckLoader.ShowDialog();
        }

        private void DeckLoader_FileOk(object sender, CancelEventArgs e)
        {
            List<string> newStringList = new List<string>();
            using (StreamReader reader = new StreamReader(DeckLoader.FileName))
            {
                string JsonDeck = File.ReadAllText(DeckLoader.FileName);
                try
                {
                    AIDeckInfo = JsonSerializer.Deserialize<JsonAIDeck>(JsonDeck);
                    StrategyDeckInfo = JsonSerializer.Deserialize<JsonStrategyDeck>(JsonDeck);
                    if (AIDeckInfo.MainDeckCardIds != null)
                    {
                        Deck.SetCardsByIDs(AIDeckInfo.MainDeckCardIds);
                        DeckSaver.FileName = DeckLoader.FileName;
                        DeckTypeComboBox.SelectedItem = DeckTypeComboBox.Items[1];
                        DeckNameTextBox.Text = AIDeckInfo.DeckName;
                        DeckUpdate(false);
                    }
                    else if (StrategyDeckInfo.Cards != null)
                    {
                        Deck.SetCardsByIDs(StrategyDeckInfo.AllCardIDs());
                        DeckSaver.FileName = DeckLoader.FileName;
                        DeckTypeComboBox.SelectedItem = DeckTypeComboBox.Items[0];
                        FactionTypeComboBox.SelectedItem = FactionTypeComboBox.Items[StrategyDeckInfo.Faction];
                        DeckNameTextBox.Text = StrategyDeckInfo.m_Name;
                        DeckUpdate(false);
                    }
                    else
                    {
                        MessageBox.Show("Invalid JSON File!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(DeckSaver.FileName))
            {
                DeckSaver_FileOk();
            }
            else DeckSaver.ShowDialog();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeckSaver.FileName = "Deck.json";
            DeckSaver.ShowDialog();
        }
        private void DeckSaver_FileOk()
        {
            using (StreamWriter writer = new StreamWriter(DeckSaver.FileName))
            {
                if ((DeckTypeCombo.DeckType)DeckTypeComboBox.SelectedValue == DeckTypeCombo.DeckType.AI)
                {
                    AIDeckInfo = new();
                    AIDeckInfo.MainDeckCardIds = Deck.GetCardsAsIDs();
                    string JsonDeck = JsonSerializer.Serialize(AIDeckInfo);
                    writer.Write(JsonDeck);
                }
                else
                {
                    int Faction = 0;
                    if ((FactionTypeCombo.FactionType)FactionTypeComboBox.SelectedValue == FactionTypeCombo.FactionType.Zombies)
                        Faction = 1;

                    StrategyDeckInfo = new();
                    StrategyDeckInfo.m_Name = DeckNameTextBox.Text;
                    StrategyDeckInfo.Faction = Faction;
                    string JsonDeck = StrategyDeckInfo.GetCompleteJson(Deck.Cards);
                    writer.Write(JsonDeck);
                }
            }
        }
        private void DeckSaver_FileOk(object sender, CancelEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(DeckSaver.FileName))
            {
                if ((DeckTypeCombo.DeckType)DeckTypeComboBox.SelectedValue == DeckTypeCombo.DeckType.AI)
                {
                    AIDeckInfo = new();
                    AIDeckInfo.MainDeckCardIds = Deck.GetCardsAsIDs();
                    string JsonDeck = JsonSerializer.Serialize(AIDeckInfo);
                    writer.Write(JsonDeck);
                }
                else
                {
                    int Faction = 0;
                    if ((FactionTypeCombo.FactionType)FactionTypeComboBox.SelectedValue == FactionTypeCombo.FactionType.Zombies)
                        Faction = 1;

                    StrategyDeckInfo = new();
                    StrategyDeckInfo.m_Name = DeckNameTextBox.Text;
                    StrategyDeckInfo.Faction = Faction;
                    string JsonDeck = StrategyDeckInfo.GetCompleteJson(Deck.Cards);
                    writer.Write(JsonDeck);
                }
            }
        }

        private void SearchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SearchList.SelectedValue != null) SelectedListCardID = (int)SearchList.SelectedValue;
            else SelectedListCardID = -1;
        }
        void InitializeAllCards()
        {
            SearchList.DataSource = CurrentCardItems;
            SearchList.DisplayMember = "Name";
            SearchList.ValueMember = "ID";
        }
        void InitializeDeck()
        {
            DeckList.DataSource = DisplayedDeckCards;
            DeckList.DisplayMember = "Name";
            DeckList.ValueMember = "ID";
        }
        void InitializeCombos()
        {
            BindingList<DeckTypeCombo> DeckTypeList =
            [
                new DeckTypeCombo("Strategy", DeckTypeCombo.DeckType.Strategy),
                new DeckTypeCombo("AI", DeckTypeCombo.DeckType.AI)
            ];
            DeckTypeComboBox.DataSource = DeckTypeList;
            DeckTypeComboBox.DisplayMember = "Name";
            DeckTypeComboBox.ValueMember = "Type";

            BindingList<FactionTypeCombo> FactionTypeList =
            [
                new FactionTypeCombo("Plants", FactionTypeCombo.FactionType.Plants),
                new FactionTypeCombo("Zombies", FactionTypeCombo.FactionType.Zombies)
            ];
            FactionTypeComboBox.DataSource = FactionTypeList;
            FactionTypeComboBox.DisplayMember = "Name";
            FactionTypeComboBox.ValueMember = "Faction";
        }

        private void CardSearch_TextChanged(object sender, EventArgs e)
        {
            CurrentCardItems.Clear();
            CurrentSearchListPage = 0;
            SearchedCards.Clear();

            if (CardSearch.Text == "")
            {
                SetSearchListPageLabel();
                return;
            }

            foreach (CardItem card in EditableDeck.AllCardItems)
            {
                string cardName = card.Name.ToLower();
                string searchText = CardSearch.Text.ToLower();
                if (cardName.Contains(searchText))
                {
                    SearchedCards.Add(card);
                }
            }
            if (SearchedCards.Count < 1)
            {
                SetSearchListPageLabel();
                return;
            }
            foreach (CardItem Card in SearchedCards.Take(20))
            {
                CurrentCardItems.Add(Card);
            }
            SetSearchListPageLabel();
            SearchList.SelectedItem = null;
        }
        void SetSearchListPageLabel()
        {
            if (SearchedCards.Count < 1)
            {
                SearchListPageLabel.Text = "0/0";
            }
            else
            {
                int CurrentPage = CurrentSearchListPage + 1;
                string str = CurrentPage.ToString() + "/" + (NumOfSearchPages() + 1).ToString();
                SearchListPageLabel.Text = str;
            }
        }
        void SetDeckListPageLabel()
        {
            if (Deck.UniqueCards().Count < 1)
            {
                DeckListPageLabel.Text = "0/0";
            }
            else
            {
                int CurrentPage = CurrentDeckListPage + 1;
                string str = CurrentPage.ToString() + "/" + (NumOfDeckPages() + 1).ToString() ;
                DeckListPageLabel.Text = str;
            }
        }
        private void CardAdder_Click(object sender, EventArgs e)
        {
            if (SelectedListCardID > 0)
            {
                for (int i = 0; i < CopiesToAdd.Value; i++) Deck.AddCardByID(SelectedListCardID);
                DeckUpdate(false);
            }
        }
        private void DeckUpdate(bool RemovingCards)
        {
            Deck.Cards = Deck.Cards.OrderBy(x => x.ID).ToList();
            CopiesList.Items.Clear();
            CurrentDeckListPage = Math.Clamp(CurrentDeckListPage, 0, NumOfDeckPages());
            SetDeckListPageLabel();

            List<CardItem> CardsToDisplay =
                Deck.UniqueCards().Skip(ItemsPerPage * CurrentDeckListPage).Take(ItemsPerPage).ToList();

            foreach (CardItem Card in CardsToDisplay)
                CopiesList.Items.Add("×" + Deck.CopiesOfCard(Card).ToString());

            CardCount.Text = "×" + Deck.Cards.Count.ToString();
            bool UCC = Deck.UniqueCardsUpdated();
            if (UCC)
            {
                DisplayedDeckCards.Clear();

                foreach (CardItem Card in CardsToDisplay)
                    DisplayedDeckCards.Add(EditableDeck.GetCardByID(Card.ID));

                if (RemovingCards && DeckList.Items.Count > 0)
                {
                    DeckList.SelectedItem = DeckList.Items[^1];
                    DeckList_SelectedIndexChanged();
                }
                else DeckList.SelectedItem = null;
            }
        }
        private void Deck_PageChanged()
        {
            CopiesList.Items.Clear();
            DisplayedDeckCards.Clear();

            List<CardItem> CardsToDisplay =
                Deck.UniqueCards().Skip(ItemsPerPage * CurrentDeckListPage).Take(ItemsPerPage).ToList();

            foreach (CardItem Card in CardsToDisplay)
                CopiesList.Items.Add("×" + Deck.CopiesOfCard(Card).ToString());

            foreach (CardItem Card in CardsToDisplay)
                DisplayedDeckCards.Add(EditableDeck.GetCardByID(Card.ID));

            SetDeckListPageLabel();
            DeckList.SelectedItem = null;
        }
        BindingList<CardItem> DisplayedDeckCards { get; set; } = [];

        private void CardRemover_Click(object sender, EventArgs e)
        {
            CardItem CardToRemove = Deck.Cards.Find(x => x.ID == SelectedDeckCardID);
            if (SelectedDeckCardID > 0 && CardToRemove.ID > 0)
            {
                Deck.Cards.Remove(CardToRemove);
                DeckUpdate(true);
            }
        }
        private void CardRemoverAll_Click(object sender, EventArgs e)
        {
            if (SelectedDeckCardID > 0 && Deck.Cards.Any(x => x.ID == SelectedDeckCardID))
            {
                Deck.Cards.RemoveAll(x => x.ID == SelectedDeckCardID);
                DeckUpdate(true);
            }
        }
        private void DeckList_SelectedIndexChanged()
        {
            if (DeckList.SelectedValue != null) SelectedDeckCardID = (int)DeckList.SelectedValue;
            else SelectedDeckCardID = -1;
        }
        private void DeckList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DeckList.SelectedValue != null) SelectedDeckCardID = (int)DeckList.SelectedValue;
            else SelectedDeckCardID = -1;
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure? All unsaved data will be lost!",
                "New Deck", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Deck.Cards.Clear();
                DeckSaver.FileName = "";
                DeckUpdate(false);
                DeckNameTextBox.Text = "";
            }
        }
        void SearchList_PageChanged()
        {
            CurrentCardItems.Clear();
            foreach (CardItem Card in SearchedCards.Skip(CurrentSearchListPage * 20).Take(20))
            {
                CurrentCardItems.Add(Card);
            }
            SetSearchListPageLabel();
            SearchList.SelectedItem = null;
        }

        private void SearchListScrollLeft_Click(object sender, EventArgs e)
        {
            if (SearchedCards.Count > ItemsPerPage)
            {
                int NewPage = Math.Max(CurrentSearchListPage - 1, 0);
                if (CurrentSearchListPage != NewPage)
                {
                    CurrentSearchListPage = NewPage;
                    SearchList_PageChanged();
                }
            }
        }
        int NumOfSearchPages()
        {
            return Math.Max(0, (int)Math.Floor((SearchedCards.Count - 1) / (float)ItemsPerPage));
        }
        private void SearchListScrollRight_Click(object sender, EventArgs e)
        {
            if (SearchedCards.Count > ItemsPerPage)
            {
                int NewPage = Math.Min(CurrentSearchListPage + 1, NumOfSearchPages());
                if (CurrentSearchListPage != NewPage)
                {
                    CurrentSearchListPage = NewPage;
                    SearchList_PageChanged();
                }
            }
        }

        private void DeckListScrollLeft_Click(object sender, EventArgs e)
        {
            if (Deck.UniqueCards().Count > ItemsPerPage)
            {
                int NewPage = Math.Max(CurrentDeckListPage - 1, 0);
                if (CurrentDeckListPage != NewPage)
                {
                    CurrentDeckListPage = NewPage;
                    Deck_PageChanged();
                }
            }
        }
        int NumOfDeckPages()
        {
            return Math.Max(0, (int)Math.Floor((Deck.UniqueCards().Count - 1) / (float)ItemsPerPage));
        }
        private void DeckListScrollRight_Click(object sender, EventArgs e)
        {
            if (Deck.UniqueCards().Count > ItemsPerPage)
            {
                int NewPage = Math.Min(CurrentDeckListPage + 1, NumOfDeckPages());
                if (CurrentDeckListPage != NewPage)
                {
                    CurrentDeckListPage = NewPage;
                    Deck_PageChanged();
                }
            }
        }

        private void DeckTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DeckTypeComboBox.SelectedValue is DeckTypeCombo.DeckType)
            {
                bool IsStrategyDeck = (DeckTypeCombo.DeckType)DeckTypeComboBox.SelectedValue == DeckTypeCombo.DeckType.Strategy;
                DeckNameTextBox.Enabled = IsStrategyDeck;
                FactionTypeComboBox.Enabled = IsStrategyDeck;
            }
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
            if (name.Contains("--")) Name = id.ToString() + ": " + guid;
            else Name = id.ToString() + ": " + name;
        }
    }
    public struct DeckTypeCombo
    {
        public string Name { get; set; } = "";
        public DeckType Type { get; set; }
        public enum DeckType { Strategy, AI };

        public DeckTypeCombo(string name, DeckType type)
        {
            Name = name;
            Type = type;
        }
    }
    public struct FactionTypeCombo
    {
        public string Name { get; set; } = "";

        public FactionType Faction { get; set; }
        public enum FactionType { Plants, Zombies }

        public FactionTypeCombo(string name, FactionType type) 
        {
            Name = name;
            Faction = type;
        }
    }
}
