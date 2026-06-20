using AssetsTools;
using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System.Text.Json;

namespace PvZH_Mod_Deck_Builder
{
    internal class UnityAssetHandler
    {
        AssetsManager Manager = new AssetsManager();
        BundleFileInstance BundleInstance;
        AssetBundleFile Bundle;
        AssetsFileInstance AssetFileInstance;
        AssetsFile AssetFile;
        List<BundleDeck> Decks = [];
        internal void LoadDecksFromDataAssets(string FilePath, out bool success, out List<BundleDeck> OutputDecks)
        {
            success = false;
            OutputDecks = [];
            try
            {
                BundleInstance = Manager.LoadBundleFile(FilePath, true);
                Bundle = BundleInstance.file;
                AssetFileInstance = Manager.LoadAssetsFileFromBundle(BundleInstance, 0, false);
                AssetFile = AssetFileInstance.file;
                this.Decks.Clear();
                if (AssetFile.GetAssetsOfType(AssetClassID.TextAsset).Count > 0)
                {
                    foreach (var texInfo in AssetFile.GetAssetsOfType(AssetClassID.TextAsset))
                    {
                        var texBase = Manager.GetBaseField(AssetFileInstance, texInfo);
                        string script = texBase["m_Script"].AsString;
                        if (script.Contains("MainDeckCardIds"))
                        {
                            var JsonDeck = JsonSerializer.Deserialize<JsonAIDeck>(script);
                            var cards = CardsStorage.GetCardsByIDs(JsonDeck.MainDeckCardIds);
                            this.Decks.Add(new BundleDeck(texInfo, texBase, cards, false));
                        }
                    }
                    success = true;
                }
                else
                {
                    foreach (var monoInfo in AssetFile.GetAssetsOfType(AssetClassID.MonoBehaviour))
                    {
                        var monoBase = Manager.GetBaseField(AssetFileInstance, monoInfo);
                        List<int> CardIDs = [];
                        foreach (AssetTypeValueField Card in monoBase["Cards.CardEntries.Array"])
                        {
                            int id = Card["CardGuid"].AsInt;
                            int copies = Card["NumCopies"].AsInt;
                            for (int i = 0; i < copies; i++) CardIDs.Add(id);
                        }
                        var cards = CardsStorage.GetCardsByIDs(CardIDs.ToArray());
                        this.Decks.Add(new BundleDeck(monoInfo, monoBase, cards, true));
                    }
                    success = true;
                }
                Decks = Decks.OrderBy(x => x.Name).ToList();
                if (success) OutputDecks = Decks;
            }
            catch
            {
                MessageBox.Show("Something went wrong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        internal void SaveBundle(string path)
        {
            foreach (BundleDeck Deck in Decks) Deck.SaveDeck();
            Bundle.BlockAndDirInfo.DirectoryInfos[0].SetNewData(AssetFile);
            try
            {
                using (AssetsFileWriter writer = new AssetsFileWriter(path))
                {
                    Bundle.Write(writer);
                }
            }
            catch (Exception e)
            {
                if (e is IOException) MessageBox.Show("You cannot save to the bundle you loaded! Save it as "
                    + "a new bundle.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    internal class BundleDeck
    {
        public string Name { get; set; }
        public AssetFileInfo Info { get; set; }
        public int Faction { get; set; }
        public AssetTypeValueField Base { get; set; }
        public BundleDeck Self { get; set; }
        public List<CardItem> Cards { get; set; }
        public bool IsStrategyDeck { get; set; }
        internal BundleDeck(AssetFileInfo assetinfo, AssetTypeValueField assetbase, List<CardItem> cards, bool isStrategy)
        {
            Info = assetinfo;
            Base = assetbase;
            Name = assetbase["m_Name"].AsString;
            Self = this;
            Cards = cards;
            IsStrategyDeck = isStrategy;

            if (IsStrategyDeck) Faction = assetbase["Faction"].AsInt;
            else Faction = 0;
        }
        internal void SaveDeck()
        {
            if (!IsStrategyDeck)
            {
                JsonAIDeck AIDeckInfo = new();
                AIDeckInfo.MainDeckCardIds = Cards.Select(card => card.ID).ToArray();
                string JsonDeck = JsonSerializer.Serialize(AIDeckInfo);
                Base["m_Script"].AsString = JsonDeck;
                Info.SetNewData(Base);
            }
            else
            {
                var CardIDs = Cards.Select(card => card.ID).ToArray();
                var UniqueCardIDs = CardIDs.Distinct();
                List<(int, int)> CardIDsAndCopies = [];
                var baseArray = Base["Cards.CardEntries.Array"];
                List<AssetTypeValueField> newChildren = [];

                foreach (int ID in UniqueCardIDs)
                {
                    var newChild = ValueBuilder.DefaultValueFieldFromArrayTemplate(baseArray);
                    newChild["CardGuid"].AsInt = ID;
                    newChild["Faction"].AsInt = Faction;
                    newChild["Filter"].AsString = "";
                    newChild["NumCopies"].AsInt = CardIDs.Count(ID);
                    newChild["Guid"].AsString = CardsStorage.GetCardByID(ID).Guid;
                    newChildren.Add(newChild);
                }
                Base["Cards.CardEntries.Array"].Children = newChildren;
                Info.SetNewData(Base);
            }
        }
    }
}
