using System.Net;

namespace PvZH_Mod_Deck_Builder
{
    internal static class CardsStorage
    {

        public static List<CardItem> AllCardItems = [];
        public static string PathToFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PvZH Deck Builder");

        public static CardItem GetCardByID(int id)
        {
            CardItem card = AllCardItems.Find(x => x.ID == id);
            if (card.ID > 0) return card;

            card = new CardItem(id, "MISSING_CARD_" + id, "MISSING_GUID_" + id);
            AllCardItems.Add(card);
            return card;
        }
        public static List<CardItem> GetCardsByIDs(int[] ids)
        {
            return ids.Order().Select(GetCardByID).ToList();
        }
        public static void SetCustomCards(string[] lines)
        {
            AllCardItems.Clear();
            foreach (string CDK in CardDataHandler.LoadedCardData.Keys)
            {
                string prefabname = CardDataHandler.LoadedCardData[CDK].prefabName;
                string CSVSearcher = prefabname + "_name";
                string? nameline = lines.FirstOrDefault(x => x.StartsWith(CSVSearcher));
                if (nameline != null)
                {
                    int id = int.Parse(CDK);
                    string cardname = nameline.Split(',')[1];
                    cardname = cardname.Replace(" ", "!-spckey-!");
                    cardname = System.Text.RegularExpressions.Regex.Replace(WebUtility.HtmlDecode(cardname), "<.*?>", "");
                    cardname = cardname.Replace("!-spckey-!", " ");
                    AllCardItems.Add(new CardItem(id, cardname, prefabname));
                }
            }
        }
    }
    internal class CardDataHandler
    {
        public static Dictionary<string, CardData> LoadedCardData { get; set; } = [];
        public class CardData
        {
            public string prefabName { get; set; } = "";
        }
    }
}
