namespace PvZH_Mod_Deck_Builder
{
    partial class CardDataModifier
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ECI = new EditableCardItem();
            SearchCardToModLabel = new Label();
            SearchIDNumeric = new NumericUpDown();
            SearchModButton = new Button();
            menuStrip1 = new MenuStrip();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            deleteCurrentCardToolStripMenuItem = new ToolStripMenuItem();
            resetToDefaultToolStripMenuItem = new ToolStripMenuItem();
            currentToolStripMenuItem = new ToolStripMenuItem();
            allToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)SearchIDNumeric).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ECI
            // 
            ECI.Location = new Point(0, 124);
            ECI.Name = "ECI";
            ECI.Size = new Size(734, 34);
            ECI.TabIndex = 0;
            // 
            // SearchCardToModLabel
            // 
            SearchCardToModLabel.AutoSize = true;
            SearchCardToModLabel.Location = new Point(267, 32);
            SearchCardToModLabel.Name = "SearchCardToModLabel";
            SearchCardToModLabel.Size = new Size(164, 20);
            SearchCardToModLabel.TabIndex = 2;
            SearchCardToModLabel.Text = "Search/Add Card By ID:";
            // 
            // SearchIDNumeric
            // 
            SearchIDNumeric.Location = new Point(437, 30);
            SearchIDNumeric.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            SearchIDNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            SearchIDNumeric.Name = "SearchIDNumeric";
            SearchIDNumeric.Size = new Size(52, 27);
            SearchIDNumeric.TabIndex = 3;
            SearchIDNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SearchModButton
            // 
            SearchModButton.Location = new Point(300, 66);
            SearchModButton.Name = "SearchModButton";
            SearchModButton.Size = new Size(131, 38);
            SearchModButton.TabIndex = 4;
            SearchModButton.Text = "Search";
            SearchModButton.UseVisualStyleBackColor = true;
            SearchModButton.Click += SearchModButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(733, 28);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, deleteCurrentCardToolStripMenuItem, resetToDefaultToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(75, 24);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(276, 26);
            saveToolStripMenuItem.Text = "Save Changes";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // deleteCurrentCardToolStripMenuItem
            // 
            deleteCurrentCardToolStripMenuItem.Name = "deleteCurrentCardToolStripMenuItem";
            deleteCurrentCardToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            deleteCurrentCardToolStripMenuItem.Size = new Size(276, 26);
            deleteCurrentCardToolStripMenuItem.Text = "Delete Current Card";
            deleteCurrentCardToolStripMenuItem.Click += deleteCurrentCardToolStripMenuItem_Click;
            // 
            // resetToDefaultToolStripMenuItem
            // 
            resetToDefaultToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { currentToolStripMenuItem, allToolStripMenuItem });
            resetToDefaultToolStripMenuItem.Name = "resetToDefaultToolStripMenuItem";
            resetToDefaultToolStripMenuItem.Size = new Size(276, 26);
            resetToDefaultToolStripMenuItem.Text = "Reset To Default...";
            // 
            // currentToolStripMenuItem
            // 
            currentToolStripMenuItem.Name = "currentToolStripMenuItem";
            currentToolStripMenuItem.Size = new Size(224, 26);
            currentToolStripMenuItem.Text = "Current Card";
            currentToolStripMenuItem.Click += currentToolStripMenuItem_Click;
            // 
            // allToolStripMenuItem
            // 
            allToolStripMenuItem.Name = "allToolStripMenuItem";
            allToolStripMenuItem.Size = new Size(224, 26);
            allToolStripMenuItem.Text = "All Cards";
            allToolStripMenuItem.Click += ResetAllToDefaultToolStripMenuItem_Click;
            // 
            // CardDataModifier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 186);
            Controls.Add(SearchModButton);
            Controls.Add(SearchIDNumeric);
            Controls.Add(SearchCardToModLabel);
            Controls.Add(ECI);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CardDataModifier";
            Text = "Modify Card Data";
            FormClosing += CardDataModifier_FormClosing;
            Load += CardDataModifier_Load;
            ((System.ComponentModel.ISupportInitialize)SearchIDNumeric).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private EditableCardItem ECI;
        private Label SearchCardToModLabel;
        private NumericUpDown SearchIDNumeric;
        private Button SearchModButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem resetToDefaultToolStripMenuItem;
        private ToolStripMenuItem currentToolStripMenuItem;
        private ToolStripMenuItem allToolStripMenuItem;
        private ToolStripMenuItem deleteCurrentCardToolStripMenuItem;
    }
}