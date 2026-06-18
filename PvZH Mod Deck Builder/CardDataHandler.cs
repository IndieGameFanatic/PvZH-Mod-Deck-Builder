namespace PvZH_Mod_Deck_Builder
{
    internal class CardDataHandler
    {
        public static Dictionary<string, CardData> LoadedCardData { get; set; } = [];
        public class CardData
        {
            public string prefabName { get; set; } = "";
        }
    }
}
