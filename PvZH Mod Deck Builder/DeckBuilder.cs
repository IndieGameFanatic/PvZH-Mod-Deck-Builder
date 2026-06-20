using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PvZH_Mod_Deck_Builder
{
    public partial class DeckBuilder : Form
    {
        string savedName = "PvZH Deck Builder for Mods";
        string unsavedName = "(*) PvZH Deck Builder for Mods";
        BundleDeck CurrentBundleDeck = null;
        // TODO: Make pages for DeckList and CardList
        int SelectedListCardID = -1;
        int SelectedDeckCardID = -1;
        int ItemsPerPage = 20;
        Size noBundleSize = new Size(712, 647);
        Size withBundleSize = new Size(1054, 647);
        UnityAssetHandler UAH = new UnityAssetHandler();

        List<CardItem> Deck = [];
        List<CardItem> SearchedCards = [];
        List<BundleDeck> AllBundleDecks = [];

        public BindingList<CardItem> DisplayedSearchedCards = [];
        BindingList<CardItem> DisplayedDeckCards { get; set; } = [];
        BindingList<BundleDeck> DisplayedBundleDecks = [];

        int CurrentCardSearchPage = 0;
        int CurrentDeckListPage = 0;
        int CurrentDeckSearchPage = 0;

        public DeckBuilder()
        {
            InitializeComponent();
        }

        private void DeckBuilder_Load(object sender, EventArgs e)
        {
            InitializeCardData();
            InitializeDataSources();
            InitializeCombos();
            this.Size = noBundleSize;
        }
        void InitializeCardData()
        {
            string folderpath = Path.Combine(Application.StartupPath, "autoload");
            string datapath = Path.Combine(folderpath, "cards.txt");
            string namepath = Path.Combine(folderpath, "localizedstrings.txt");
            if (!File.Exists(datapath) || !File.Exists(namepath))
            {
                MessageBox.Show("'cards.txt' and/or 'localizedstrings.txt' in 'autoload' folder are missing, " +
                    "so no cards can be loaded!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string jsondata = File.ReadAllText(datapath);
            LoadCardDataFromJson(jsondata, out bool success);
            if (success)
            {
                string[] jsonnames = File.ReadAllLines(namepath);
                CardsStorage.SetCustomCards(jsonnames);
                DeckUpdate(false);
                CardSearch_TextChanged(new(), new());
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeckLoader.ShowDialog();
        }
        void LoadDeckFromJson(string JsonDeck)
        {
            try
            {
                AllBundleDecks.Clear();
                DisplayedBundleDecks.Clear();
                JsonAIDeck AIDeckInfo = JsonSerializer.Deserialize<JsonAIDeck>(JsonDeck);
                JsonStrategyDeck StrategyDeckInfo = JsonSerializer.Deserialize<JsonStrategyDeck>(JsonDeck);
                if (AIDeckInfo.MainDeckCardIds != null)
                {
                    var Cards = CardsStorage.GetCardsByIDs(AIDeckInfo.MainDeckCardIds);
                    LoadAIDeck(Cards);
                }
                else if (StrategyDeckInfo.Cards != null)
                {
                    var Cards = CardsStorage.GetCardsByIDs(StrategyDeckInfo.AllCardIDs());
                    LoadStrategyDeck(Cards, StrategyDeckInfo.m_Name, StrategyDeckInfo.Faction);
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
        void LoadAIDeck(List<CardItem> Cards)
        {
            Deck = Cards;
            DeckTypeComboBox.SelectedItem = DeckTypeComboBox.Items[1];
            DeckNameTextBox.Text = "";
            CurrentDeckListPage = 0;
            CurrentBundleDeck = null;
            DeckUpdate(false);
            DeckSearch.Enabled = false;
            DeckSearchList.Enabled = false;
            DeckTypeComboBox.Enabled = true;
            this.Text = savedName;
            this.Size = noBundleSize;
            DeckSaver.FileName = DeckLoader.FileName;
        }
        void LoadStrategyDeck(List<CardItem> Cards, string Name, int Faction)
        {
            Deck = Cards;
            DeckTypeComboBox.SelectedItem = DeckTypeComboBox.Items[0];
            FactionTypeComboBox.SelectedItem = FactionTypeComboBox.Items[Faction];
            DeckNameTextBox.Text = Name;
            CurrentDeckListPage = 0;
            CurrentBundleDeck = null;
            DeckUpdate(false);
            DeckSearch.Enabled = false;
            DeckSearchList.Enabled = false;
            DeckTypeComboBox.Enabled = true;
            this.Text = savedName;
            this.Size = noBundleSize;
            DeckSaver.FileName = DeckLoader.FileName;
        }
        void LoadBundleDeck(BundleDeck deck)
        {
            Deck = deck.Cards;
            DeckNameTextBox.Text = deck.Name;
            CurrentDeckListPage = 0;
            CurrentBundleDeck = deck;
            DeckUpdate(false);
            DeckSearch.Enabled = true;
            DeckSearchList.Enabled = true;
            DeckTypeComboBox.Enabled = false;
            this.Text = savedName;
            this.Size = withBundleSize;
            DeckSaver.FileName = "";
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
                JsonAIDeck AIDeckInfo = new();
                AIDeckInfo.MainDeckCardIds = Deck.Select(card => card.ID).ToArray();
                JsonDeck = JsonSerializer.Serialize(AIDeckInfo);
            }
            else
            {
                JsonStrategyDeck StrategyDeckInfo = new();
                StrategyDeckInfo.m_Name = DeckNameTextBox.Text;
                StrategyDeckInfo.Faction = FactionTypeComboBox.SelectedIndex == 1 ? 1 : 0;
                JsonDeck = StrategyDeckInfo.GetCompleteJson(Deck);
            }
            File.WriteAllText(DeckSaver.FileName, JsonDeck);
            this.Text = savedName;
        }

        private void CardSearchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CardSearchList.SelectedValue != null) SelectedListCardID = (int)CardSearchList.SelectedValue;
            else SelectedListCardID = -1;
        }
        void InitializeDataSources()
        {
            CardSearchList.DataSource = DisplayedSearchedCards;
            CardSearchList.DisplayMember = "Name";
            CardSearchList.ValueMember = "ID";

            DeckList.DataSource = DisplayedDeckCards;
            DeckList.DisplayMember = "Name";
            DeckList.ValueMember = "ID";

            DeckSearchList.DataSource = DisplayedBundleDecks;
            DeckSearchList.DisplayMember = "Name";
            DeckSearchList.ValueMember = "Self";
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
            DisplayedSearchedCards.Clear();
            CardIDList.Items.Clear();
            SearchedCards.Clear();

            if (CardSearch.Text == "")
            {
                SetCardSearchPageLabel();
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
                SetCardSearchPageLabel();
                return;
            }

            CurrentCardSearchPage = 0;
            CardSearch_PageChanged();
            CardSearchList.SelectedItem = null;
        }
        void SetCardSearchPageLabel()
        {
            if (SearchedCards.Count < 1)
            {
                CardSearchPageLabel.Text = "0/0";
            }
            else
            {
                int CurrentPage = CurrentCardSearchPage + 1;
                string str = CurrentPage.ToString() + "/" + (NumOfSearchPages() + 1).ToString();
                CardSearchPageLabel.Text = str;
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

            if (CurrentBundleDeck != null)
            {
                CurrentBundleDeck.Cards.Clear();
                foreach (CardItem Card in Deck) CurrentBundleDeck.Cards.Add(Card);
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
                LoadStrategyDeck([], "", 0);
            }
        }
        void CardSearch_PageChanged()
        {
            DisplayedSearchedCards.Clear();
            CardIDList.Items.Clear();
            foreach (CardItem Card in SearchedCards.Skip(CurrentCardSearchPage * 20).Take(20))
            {
                DisplayedSearchedCards.Add(Card);
                CardIDList.Items.Add(Card.ID.ToString());
            }
            SetCardSearchPageLabel();
            CardSearchList.SelectedItem = null;
        }

        private void CardSearchListScrollLeft_Click(object sender, EventArgs e)
        {
            if (SearchedCards.Count > ItemsPerPage)
            {
                int NewPage = Math.Max(CurrentCardSearchPage - 1, 0);
                if (CurrentCardSearchPage != NewPage)
                {
                    CurrentCardSearchPage = NewPage;
                    CardSearch_PageChanged();
                }
            }
        }
        int NumOfSearchPages()
        {
            return Math.Max(0, (int)Math.Floor((SearchedCards.Count - 1) / (float)ItemsPerPage));
        }
        private void CardSearchScrollRight_Click(object sender, EventArgs e)
        {
            if (SearchedCards.Count > ItemsPerPage)
            {
                int NewPage = Math.Min(CurrentCardSearchPage + 1, NumOfSearchPages());
                if (CurrentCardSearchPage != NewPage)
                {
                    CurrentCardSearchPage = NewPage;
                    CardSearch_PageChanged();
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

        private void loadCardDataFromFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = CardFolderLoader.ShowDialog();
            if (result == DialogResult.OK)
            {
                CardFolderLoader_FolderOK();
            }
        }

        void LoadCardDataFromJson(string JsonData, out bool success)
        {
            success = false;
            try
            {
                CardDataHandler.LoadedCardData = JsonSerializer.Deserialize<Dictionary<string, CardDataHandler.CardData>>(JsonData) ?? [];
                if (CardDataHandler.LoadedCardData.Values.Count > 0)
                {
                    success = true;
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

        private void resetToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeCardData();
        }

        private void UnityAssetLoader_FileOk(object sender, CancelEventArgs e)
        {
            UAH.LoadDecksFromDataAssets(UnityAssetLoader.FileName, out bool success, out List<BundleDeck> decks);
            if (success)
            {
                AllBundleDecks.Clear();
                DisplayedBundleDecks.Clear();
                foreach (BundleDeck deck in decks) AllBundleDecks.Add(deck);
                CurrentDeckSearchPage = 0;
                DeckSearch_PageChanged();
                DeckSearchList.SelectedItem = DeckSearchList.Items[0];
                DeckSearchList_SelectedIndexChanged(new(), new());

                if (AllBundleDecks[0].IsStrategyDeck)
                {
                    DeckTypeComboBox.SelectedItem = DeckTypeComboBox.Items[0];
                }
                else
                {
                    DeckTypeComboBox.SelectedItem = DeckTypeComboBox.Items[1];
                }
            }
        }

        private void loadBundleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnityAssetLoader.ShowDialog();
        }

        private void CardFolderLoader_FolderOK()
        {
            string folderpath = CardFolderLoader.SelectedPath;
            string datapath = Path.Combine(folderpath, "cards.txt");
            string namepath = Path.Combine(folderpath, "localizedstrings.txt");
            if (!File.Exists(datapath) || !File.Exists(namepath))
            {
                MessageBox.Show("'cards.txt' and/or 'localizedstrings.txt' are missing from the selected folder, " +
                    "so no cards can be loaded!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string jsondata = File.ReadAllText(datapath);
            LoadCardDataFromJson(jsondata, out bool success);
            if (success)
            {
                string[] jsonnames = File.ReadAllLines(namepath);
                CardsStorage.SetCustomCards(jsonnames);
                DeckUpdate(false);
                CardSearch_TextChanged(new(), new());
            }
        }

        private void DeckSearchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BundleDeck bDeck = (BundleDeck)DeckSearchList.SelectedValue;
            if (bDeck != null) LoadBundleDeck(bDeck);
        }
        private void DeckSearchScrollLeft_Click(object sender, EventArgs e)
        {
            if (AllBundleDecks.Count > ItemsPerPage)
            {
                int NewPage = Math.Max(CurrentDeckSearchPage - 1, 0);
                if (CurrentDeckSearchPage != NewPage)
                {
                    CurrentDeckSearchPage = NewPage;
                    DeckSearch_PageChanged();
                }
            }
        }
        private void DeckSearchScrollRight_Click(object sender, EventArgs e)
        {
            if (AllBundleDecks.Count > ItemsPerPage)
            {
                int NewPage = Math.Min(CurrentDeckSearchPage + 1, NumOfDeckSearchPages());
                if (CurrentDeckSearchPage != NewPage)
                {
                    CurrentDeckSearchPage = NewPage;
                    DeckSearch_PageChanged();
                }
            }
        }
        void DeckSearch_PageChanged()
        {
            DisplayedBundleDecks.Clear();
            foreach (BundleDeck deck in CurrentPageSearchedDecks())
            {
                DisplayedBundleDecks.Add(deck);
            }
            SetDeckSearchPageLabel();
            DeckSearchList.SelectedItem = null;
        }
        List<BundleDeck> SearchedDecks()
        {
            return AllBundleDecks.FindAll(x => x.Name.Contains(DeckSearch.Text, StringComparison.OrdinalIgnoreCase));
        }
        List<BundleDeck> CurrentPageSearchedDecks()
        {
            return SearchedDecks().Skip(CurrentDeckSearchPage * 20).Take(20).ToList();
        }
        int NumOfDeckSearchPages()
        {
            return Math.Max(0, (int)Math.Floor((SearchedDecks().Count - 1) / (float)ItemsPerPage));
        }
        void SetDeckSearchPageLabel()
        {
            if (AllBundleDecks.Count < 1)
            {
                DeckSearchPageLabel.Text = "0/0";
            }
            else
            {
                int CurrentPage = CurrentDeckSearchPage + 1;
                string str = CurrentPage.ToString() + "/" + (NumOfDeckSearchPages() + 1).ToString();
                DeckSearchPageLabel.Text = str;
            }
        }

        private void DeckSearch_TextChanged(object sender, EventArgs e)
        {
            if (AllBundleDecks.Count <= 0) return;
            CurrentDeckSearchPage = 0;
            DeckSearch_PageChanged();
        }
    }
}
