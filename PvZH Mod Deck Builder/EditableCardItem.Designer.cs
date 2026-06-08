namespace PvZH_Mod_Deck_Builder
{
    partial class EditableCardItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CardIDLabel = new Label();
            CardNameTextBox = new TextBox();
            CardGuidTextBox = new TextBox();
            SuspendLayout();
            // 
            // CardIDLabel
            // 
            CardIDLabel.AutoSize = true;
            CardIDLabel.Location = new Point(3, 6);
            CardIDLabel.Name = "CardIDLabel";
            CardIDLabel.Size = new Size(27, 20);
            CardIDLabel.TabIndex = 0;
            CardIDLabel.Text = "ID:";
            // 
            // CardNameTextBox
            // 
            CardNameTextBox.Enabled = false;
            CardNameTextBox.Location = new Point(45, 3);
            CardNameTextBox.Name = "CardNameTextBox";
            CardNameTextBox.Size = new Size(328, 27);
            CardNameTextBox.TabIndex = 2;
            CardNameTextBox.Text = "Name...";
            CardNameTextBox.TextChanged += CardNameTextBox_TextChanged;
            // 
            // CardGuidTextBox
            // 
            CardGuidTextBox.Enabled = false;
            CardGuidTextBox.Location = new Point(399, 3);
            CardGuidTextBox.Margin = new Padding(23, 3, 3, 3);
            CardGuidTextBox.Name = "CardGuidTextBox";
            CardGuidTextBox.Size = new Size(328, 27);
            CardGuidTextBox.TabIndex = 3;
            CardGuidTextBox.Text = "GUID/Prefab...";
            CardGuidTextBox.TextChanged += CardGuidTextBox_TextChanged;
            // 
            // EditableCardItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CardGuidTextBox);
            Controls.Add(CardNameTextBox);
            Controls.Add(CardIDLabel);
            Name = "EditableCardItem";
            Size = new Size(730, 34);
            Load += EditableCardItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CardIDLabel;
        private TextBox CardNameTextBox;
        private TextBox CardGuidTextBox;
    }
}
