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
    }
    internal class BundleDeck
    {
        public string Name { get; set; }
        public AssetFileInfo Info { get; set; }
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
        }
    }
}
