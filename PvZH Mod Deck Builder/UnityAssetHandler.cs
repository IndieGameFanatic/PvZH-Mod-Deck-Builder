using AssetsTools;
using AssetsTools.NET;
using AssetsTools.NET.Extra;

namespace PvZH_Mod_Deck_Builder
{
    internal class UnityAssetHandler
    {
        AssetsManager Manager = new AssetsManager();
        BundleFileInstance BundleInstance;
        AssetBundleFile Bundle;
        AssetsFileInstance AssetFileInstance;
        AssetsFile AssetFile;
        List<AIAssetDeck> AIDecks = [];
        internal void LoadDecksFromDataAssets(string FilePath)
        {
            try
            {
                BundleInstance = Manager.LoadBundleFile(FilePath, true);
                Bundle = BundleInstance.file;
                AssetFileInstance = Manager.LoadAssetsFileFromBundle(BundleInstance, 0, false);
                AssetFile = AssetFileInstance.file;
                AIDecks.Clear();
                foreach (var texInfo in AssetFile.GetAssetsOfType(AssetClassID.TextAsset))
                {
                    var texBase = Manager.GetBaseField(AssetFileInstance, texInfo);
                    var script = texBase["m_Script"].AsString;
                    if (script.Contains("MainDeckCardIds"))
                    {
                        AIDecks.Add(new AIAssetDeck(texInfo, texBase));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        internal class AIAssetDeck
        {
            public string Name { get; set; }
            public AssetFileInfo Info { get; set; }
            public AssetTypeValueField Base { get; set; }
            public string Json { get; set; }
            internal AIAssetDeck(AssetFileInfo assetinfo, AssetTypeValueField assetbase)
            {
                Info = assetinfo;
                Base = assetbase;
                Json = assetbase["m_Script"].AsString;
                Name = assetbase["m_Name"].AsString;
            }
        }
    }
    
}
