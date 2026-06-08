using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PvZH_Mod_Deck_Builder
{
    public partial class EditableCardItem : UserControl
    {
        public List<CardItem> MCIList = [];
        public int SelectedIndex = -1;
        public EditableCardItem()
        {
            InitializeComponent();
        }
        private void EditableCardItem_Load(object sender, EventArgs e)
        {

        }
        public CardItem Card()
        {
            return MCIList[SelectedIndex];
        }
        public bool CardExists()
        {
            return SelectedIndex >= 0;
        }
        public void SetCardItemToEdit(List<CardItem> MCI, int index)
        {
            MCIList = MCI;
            SelectedIndex = index;
            if (SelectedIndex >= 0)
            {
                CardItem Card = MCIList[SelectedIndex];
                CardIDLabel.Text = Card.ID.ToString() + ":";
                CardNameTextBox.Text = Card.Name;
                CardGuidTextBox.Text = Card.Guid;
                CardNameTextBox.Enabled = true;
                CardGuidTextBox.Enabled = true;
            }
            else
            {
                CardIDLabel.Text = "ID:";
                CardNameTextBox.Text = "Name...";
                CardGuidTextBox.Text = "GUID/Prefab...";
                CardNameTextBox.Enabled = false;
                CardGuidTextBox.Enabled = false;
            }
        }
        void CardItem_Updated()
        {
            if (SelectedIndex >= 0)
            {
                CardItem NewCard =
                    new CardItem(MCIList[SelectedIndex].ID, CardNameTextBox.Text, CardGuidTextBox.Text);
                MCIList[SelectedIndex] = NewCard;
            }
        }

        private void CardNameTextBox_TextChanged(object sender, EventArgs e)
        {
            CardItem_Updated();
        }

        private void CardGuidTextBox_TextChanged(object sender, EventArgs e)
        {
            CardItem_Updated();
        }
    }
}
