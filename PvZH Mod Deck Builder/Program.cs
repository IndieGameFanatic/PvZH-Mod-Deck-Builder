namespace PvZH_Mod_Deck_Builder
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new DeckBuilder());
        }
    }
}