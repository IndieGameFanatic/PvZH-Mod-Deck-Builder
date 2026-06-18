using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;

namespace PvZH_Mod_Deck_Builder
{
    public partial class DeckBuilder : Form
    {
        string savedName = "PvZH Deck Builder for Mods";
        string unsavedName = "(*) PvZH Deck Builder for Mods";
        // TODO: Make pages for DeckList and CardList
        JsonAIDeck AIDeckInfo = new();
        JsonStrategyDeck StrategyDeckInfo = new();
        List<CardItem> Deck = [];
        public BindingList<CardItem> CurrentCardItems = [];
        List<CardItem> SearchedCards = [];
        int SelectedListCardID = -1;
        int SelectedDeckCardID = -1;
        int CurrentSearchListPage = 0;
        int CurrentDeckListPage = 0;
        int ItemsPerPage = 20;
        UnityAssetHandler UAH = new UnityAssetHandler();
        public DeckBuilder()
        {
            InitializeComponent();
        }

        private void DeckBuilder_Load(object sender, EventArgs e)
        {
            CardsStorage.LoadDefaultCards();
            InitializeAllCards();
            InitializeDeck();
            InitializeCombos();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeckLoader.ShowDialog();
        }
        void LoadDeckFromJson(string JsonDeck)
        {
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
                    this.Text = savedName;
                }
                else if (StrategyDeckInfo.Cards != null)
                {
                    Deck.SetCardsByIDs(StrategyDeckInfo.AllCardIDs());
                    DeckSaver.FileName = DeckLoader.FileName;
                    DeckTypeComboBox.SelectedItem = DeckTypeComboBox.Items[0];
                    FactionTypeComboBox.SelectedItem = FactionTypeComboBox.Items[StrategyDeckInfo.Faction];
                    DeckNameTextBox.Text = StrategyDeckInfo.m_Name;
                    DeckUpdate(false);
                    this.Text = savedName;
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
        private void DeckLoader_FileOk(object sender, CancelEventArgs e)
        {
            List<string> newStringList = new List<string>();
            using (StreamReader reader = new StreamReader(DeckLoader.FileName))
            {
                string JsonDeck = File.ReadAllText(DeckLoader.FileName);
                LoadDeckFromJson(JsonDeck);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(DeckSaver.FileName))
            {
                DeckSaver_FileOk(sender, new());
            }
            else DeckSaver.ShowDialog();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeckSaver.FileName = "Deck.json";
            DeckSaver.ShowDialog();
        }
        private void DeckSaver_FileOk(object sender, CancelEventArgs e)
        {
            string JsonDeck;
            if (DeckTypeComboBox.SelectedIndex == 1)
            {
                AIDeckInfo = new();
                AIDeckInfo.MainDeckCardIds = Deck.Select(card => card.ID).ToArray();
                JsonDeck = JsonSerializer.Serialize(AIDeckInfo);
            }
            else
            {
                StrategyDeckInfo = new();
                StrategyDeckInfo.m_Name = DeckNameTextBox.Text;
                StrategyDeckInfo.Faction = FactionTypeComboBox.SelectedIndex == 1 ? 1 : 0;
                JsonDeck = StrategyDeckInfo.GetCompleteJson(Deck);
            }
            File.WriteAllText(DeckSaver.FileName, JsonDeck);
            this.Text = savedName;
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
            DeckTypeComboBox.Items.Clear();
            DeckTypeComboBox.Items.AddRange(["Strategy", "AI"]);
            DeckTypeComboBox.SelectedIndex = 0;

            FactionTypeComboBox.Items.Clear();
            FactionTypeComboBox.Items.AddRange(["Plants", "Zombies"]);
            FactionTypeComboBox.SelectedIndex = 0;
        }

        private void CardSearch_TextChanged(object sender, EventArgs e)
        {
            CurrentCardItems.Clear();
            CardIDList.Items.Clear();
            CurrentSearchListPage = 0;
            SearchedCards.Clear();

            if (CardSearch.Text == "")
            {
                SetSearchListPageLabel();
                return;
            }

            foreach (CardItem Card in CardsStorage.AllCardItems)
            {
                if (Card.Name.Contains(CardSearch.Text, StringComparison.OrdinalIgnoreCase) || int.TryParse(CardSearch.Text, out int ParsedID) && ParsedID == Card.ID)
                {
                    SearchedCards.Add(Card);
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
                CardIDList.Items.Add(Card.ID.ToString());
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
            if (!UniqueDeckCards().Any())
            {
                DeckListPageLabel.Text = "0/0";
            }
            else
            {
                int CurrentPage = CurrentDeckListPage + 1;
                string str = CurrentPage.ToString() + "/" + (NumOfDeckPages() + 1).ToString();
                DeckListPageLabel.Text = str;
            }
        }
        private void CardAdder_Click(object sender, EventArgs e)
        {
            if (SelectedListCardID > 0)
            {
                for (int i = 0; i < CopiesToAdd.Value; i++) Deck.Add(CardsStorage.GetCardByID(SelectedListCardID));
                DeckUpdate(false);
                this.Text = unsavedName;
            }

        }
        IEnumerable<CardItem> UniqueDeckCards() => Deck.DistinctBy(x => x.ID);
        private void DeckUpdate(bool RemovingCards)
        {
            Deck = Deck.OrderBy(x => x.ID).ToList();
            CurrentDeckListPage = Math.Clamp(CurrentDeckListPage, 0, NumOfDeckPages());
            Deck_PageChanged();

            if (RemovingCards && DeckList.Items.Count > 0)
            {
                DeckList.SelectedItem = DeckList.Items[^1];
                DeckList_SelectedIndexChanged();
            }
        }
        private void Deck_PageChanged()
        {
            CopiesList.Items.Clear();
            DisplayedDeckCards.Clear();
            CardCount.Text = "×" + Deck.Count.ToString();

            foreach (CardItem Card in UniqueDeckCards().Skip(ItemsPerPage * CurrentDeckListPage).Take(ItemsPerPage))
            {
                CopiesList.Items.Add("×" + Deck.Count(x => x.ID == Card.ID).ToString());
                DisplayedDeckCards.Add(CardsStorage.GetCardByID(Card.ID));
            }

            SetDeckListPageLabel();
            DeckList.SelectedItem = null;
        }
        BindingList<CardItem> DisplayedDeckCards { get; set; } = [];

        private void CardRemover_Click(object sender, EventArgs e)
        {
            int CardIDToRemove = SelectedDeckCardID;
            CardItem CardToRemove = Deck.Find(x => x.ID == SelectedDeckCardID);
            if (SelectedDeckCardID > 0 && CardToRemove.ID > 0)
            {
                Deck.Remove(CardToRemove);
                DeckUpdate(true);
                if (Deck.Any(x => x.ID == CardIDToRemove)) DeckList.SelectedValue = CardIDToRemove;
                this.Text = unsavedName;
            }
        }
        private void CardRemoverAll_Click(object sender, EventArgs e)
        {
            if (SelectedDeckCardID > 0 && Deck.Any(x => x.ID == SelectedDeckCardID))
            {
                Deck.RemoveAll(x => x.ID == SelectedDeckCardID);
                DeckUpdate(true);
                this.Text = unsavedName;
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
                Deck.Clear();
                DeckSaver.FileName = "";
                DeckUpdate(false);
                DeckNameTextBox.Text = "";
                this.Text = savedName;
            }
        }
        void SearchList_PageChanged()
        {
            CurrentCardItems.Clear();
            CardIDList.Items.Clear();
            foreach (CardItem Card in SearchedCards.Skip(CurrentSearchListPage * 20).Take(20))
            {
                CurrentCardItems.Add(Card);
                CardIDList.Items.Add(Card.ID.ToString());
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
            if (UniqueDeckCards().Count() > ItemsPerPage)
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
            return Math.Max(0, (int)Math.Floor((UniqueDeckCards().Count() - 1) / (float)ItemsPerPage));
        }
        private void DeckListScrollRight_Click(object sender, EventArgs e)
        {
            if (UniqueDeckCards().Count() > ItemsPerPage)
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
            bool IsStrategyDeck = DeckTypeComboBox.SelectedIndex == 0;
            DeckNameTextBox.Enabled = IsStrategyDeck;
            FactionTypeComboBox.Enabled = IsStrategyDeck;
        }

        private void openCardDataLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", CardsStorage.PathToFolder);
        }

        private void loadCardDataFromFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CardDataLoader.ShowDialog();
        }

        private void CardDataLoader_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string CardDataJson = File.ReadAllText(CardDataLoader.FileName);
                CardDataHandler.LoadedCardData = JsonSerializer.Deserialize<Dictionary<string, CardDataHandler.CardData>>(CardDataJson) ?? [];
                if (CardDataHandler.LoadedCardData.Values.Count > 0)
                {
                    CardNameLoader.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Card Data!");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardNameLoader_FileOk(object sender, CancelEventArgs e)
        {
            string[] lines = File.ReadAllLines(CardNameLoader.FileName);
            CardsStorage.SetCustomCards(lines);
            DeckUpdate(false);
            CardSearch_TextChanged(sender, e);
        }

        private void resetToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CardsStorage.LoadDefaultCards();
            DeckUpdate(false);
            CardSearch_TextChanged(sender, e);
        }

        private void loadDeckFromUnityAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnityAssetLoader.ShowDialog();
        }
        private void UnityAssetLoader_FileOk(object sender, CancelEventArgs e)
        {
            UAH.LoadDecksFromDataAssets(UnityAssetLoader.FileName);
        }
    }
}
