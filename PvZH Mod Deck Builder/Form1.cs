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
        PvZHDeckInfo JsonDeckInfo;
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
                    JsonDeckInfo = JsonSerializer.Deserialize<PvZHDeckInfo>(JsonDeck);
                    Deck.SetCardsByIDs(JsonDeckInfo.MainDeckCardIds);
                    DeckSaver.FileName = DeckLoader.FileName;
                    DeckUpdate(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to convert this file to a PvZH Deck.", "ERROR!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            JsonDeckInfo = new();
            JsonDeckInfo.MainDeckCardIds = Deck.GetCardsAsIDs();
            using (StreamWriter writer = new StreamWriter(DeckSaver.FileName))
            {
                string JsonDeck = JsonSerializer.Serialize(JsonDeckInfo);
                writer.Write(JsonDeck);
            }
        }
        private void DeckSaver_FileOk(object sender, CancelEventArgs e)
        {
            JsonDeckInfo = new();
            JsonDeckInfo.MainDeckCardIds = Deck.GetCardsAsIDs();
            using (StreamWriter writer = new StreamWriter(DeckSaver.FileName))
            {
                string JsonDeck = JsonSerializer.Serialize(JsonDeckInfo);
                writer.Write(JsonDeck);
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
                int NumOfPages = (int)Math.Floor(SearchedCards.Count / (float)ItemsPerPage) + 1;
                int CurrentPage = CurrentSearchListPage + 1;
                string str = CurrentPage.ToString() + "/" + NumOfPages.ToString();
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
                int NumOfPages = (int)Math.Floor(Deck.UniqueCards().Count / (float)ItemsPerPage) + 1;
                int CurrentPage = CurrentDeckListPage + 1;
                string str = CurrentPage.ToString() + "/" + NumOfPages.ToString();
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
