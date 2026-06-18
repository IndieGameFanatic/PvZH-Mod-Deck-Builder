using System;
using System.Collections.Generic;
using System.Text;
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
        List<AssetFileInfo> DecksInfo = [];
        internal void LoadDecksFromBundle(string FilePath)
        {
            try
            {
                BundleInstance = Manager.LoadBundleFile(FilePath, true);
                Bundle = BundleInstance.file;
                AssetFileInstance = Manager.LoadAssetsFileFromBundle(BundleInstance, 0, false);
                AssetFile = AssetFileInstance.file;
                DecksInfo.Clear();
                foreach (var texInfo in AssetFile.GetAssetsOfType(AssetClassID.TextAsset))
                {
                    var texBase = Manager.GetBaseField(AssetFileInstance, texInfo);
                    var script = texBase["m_Script"].AsString;
                    if (script.Contains("MainDeckCardIds"))
                        DecksInfo.Add(texInfo);
                }
                ModifyDecks();
            }
            catch
            {
                MessageBox.Show("Something went wrong!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        internal void ModifyDecks()
        {
            foreach (AssetFileInfo DeckInfo in DecksInfo)
            {
                var texBase = Manager.GetBaseField(AssetFileInstance, DeckInfo);
                texBase["m_Name"].AsString += "_MODIFIED";
                DeckInfo.SetNewData(texBase);
            }
            Bundle.BlockAndDirInfo.DirectoryInfos[0].SetNewData(AssetFile);
            using (AssetsFileWriter writer = new AssetsFileWriter(Application.StartupPath + "/data_assets.mod"))
            {
                Bundle.Write(writer);
            }
        }
    }
}
