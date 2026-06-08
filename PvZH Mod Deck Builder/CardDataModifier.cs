using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PvZH_Mod_Deck_Builder
{
    public partial class CardDataModifier : Form
    {
        public List<CardItem> ModifiedCardData = [];
        public CardDataModifier()
        {
            InitializeComponent();
        }
        private void CardDataModifier_Load(object sender, EventArgs e)
        {
            ModifiedCardData.Clear();
            foreach (CardItem Card in CardsStorage.AllCardItems)
                ModifiedCardData.Add(Card);
        }
        private void SearchModButton_Click(object sender, EventArgs e)
        {
            int SearchedID = (int)SearchIDNumeric.Value;
            int SearchedCardIndex = 0;
            CardItem CardToEdit;
            if (!ModifiedCardData.Exists(x => x.ID == SearchedID))
            {
                DialogResult result = MessageBox.Show("No card with this ID exists. Would you like to create it?",
                    "Create new card?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ModifiedCardData.Add(new CardItem(SearchedID, "NEW_CARD_" + SearchedID.ToString(), "NEW_CARD_" + SearchedID.ToString()));
                    ModifiedCardData = ModifiedCardData.OrderBy(x => x.ID).ToList();
                    SearchedCardIndex = ModifiedCardData.FindIndex(x => x.ID == SearchedID);
                    ECI.SetCardItemToEdit(ModifiedCardData, SearchedCardIndex);
                }
                else
                {
                    SearchedCardIndex = -1;
                    ECI.SetCardItemToEdit(ModifiedCardData, SearchedCardIndex);
                }
            }
            else
            {
                SearchedCardIndex = ModifiedCardData.FindIndex(x => x.ID == SearchedID);
                CardToEdit = ModifiedCardData[SearchedCardIndex];
                ECI.SetCardItemToEdit(ModifiedCardData, SearchedCardIndex);
            }
        }
        private void CardDataModifier_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit? All unsaved changes will be lost!",
                "Unsaved Changes!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) e.Cancel = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CardsStorage.AllCardItems.Clear();
            foreach (CardItem Card in ModifiedCardData)
                CardsStorage.AllCardItems.Add(Card);

            CardsStorage.UpdateJsonFileWithNewCardData();
        }

        private void deleteCurrentCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ECI.CardExists()) return;

            string str =
                String.Format("Are you sure you want to delete the card named \"{0}\"?", ECI.Card().Name);

            DialogResult result = MessageBox.Show(str,
                "Delete Card?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ModifiedCardData.RemoveAt(ECI.SelectedIndex);
                ECI.SetCardItemToEdit(ModifiedCardData, -1);
            }
        }

        private void ResetAllToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset ALL cards to default? All custom cards will be lost!",
                "Reset ALL Cards?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ModifiedCardData.Clear();
                foreach (CardItem Card in CardsStorage.DefaultAllCardItems)
                    ModifiedCardData.Add(Card);

                ECI.SetCardItemToEdit(ModifiedCardData, -1);
            }
        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ECI.CardExists()) return;

            string str =
                String.Format("Are you sure you want to reset the card named \"{0}\"?", ECI.Card().Name);

            DialogResult result = MessageBox.Show(str,
                "Reset Card?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;
            if (!CardsStorage.DefaultAllCardItems.Exists(x => x.ID == ECI.Card().ID))
            {
                ModifiedCardData.RemoveAt(ECI.SelectedIndex);
                ECI.SetCardItemToEdit(ModifiedCardData, -1);
            }
            else
            {
                ModifiedCardData[ECI.SelectedIndex] = CardsStorage.DefaultAllCardItems.Find(x => x.ID == ECI.Card().ID);
                ECI.SetCardItemToEdit(ModifiedCardData, ECI.SelectedIndex);
            }
        }
    }
}
