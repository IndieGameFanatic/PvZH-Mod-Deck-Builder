namespace PvZH_Mod_Deck_Builder
{
    partial class DeckBuilder
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            filesToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            openCardDataToolStripMenuItem = new ToolStripMenuItem();
            loadCardDataFromFilesToolStripMenuItem = new ToolStripMenuItem();
            resetToDefaultToolStripMenuItem = new ToolStripMenuItem();
            deckToolStripMenuItem = new ToolStripMenuItem();
            loadDeckFromUnityAssetToolStripMenuItem = new ToolStripMenuItem();
            DeckLoader = new OpenFileDialog();
            DeckSaver = new SaveFileDialog();
            CardSearch = new RichTextBox();
            SearchList = new ListBox();
            SearchCardLabel = new Label();
            CardAdder = new Button();
            DeckLabel = new Label();
            DeckList = new ListBox();
            CardRemover = new Button();
            CopiesList = new ListBox();
            CardCount = new Label();
            CardRemoverAll = new Button();
            CopiesToAdd = new NumericUpDown();
            CopiesToAddLabel = new Label();
            SearchListScrollLeft = new Button();
            SearchListScrollRight = new Button();
            SearchListPageLabel = new Label();
            DeckListPageLabel = new Label();
            DeckListScrollRight = new Button();
            DeckListScrollLeft = new Button();
            DeckTypeLabel = new Label();
            DeckTypeComboBox = new ComboBox();
            DeckNameLabel = new Label();
            DeckNameTextBox = new TextBox();
            FactionTypeComboBox = new ComboBox();
            label1 = new Label();
            CardIDList = new ListBox();
            CardDataLoader = new OpenFileDialog();
            CardNameLoader = new OpenFileDialog();
            UnityAssetLoader = new OpenFileDialog();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CopiesToAdd).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { filesToolStripMenuItem, openCardDataToolStripMenuItem, deckToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(720, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            filesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, loadToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            filesToolStripMenuItem.Size = new Size(52, 24);
            filesToolStripMenuItem.Text = "Files";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(242, 26);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click_1;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadToolStripMenuItem.Size = new Size(242, 26);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(242, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(242, 26);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // openCardDataToolStripMenuItem
            // 
            openCardDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadCardDataFromFilesToolStripMenuItem, resetToDefaultToolStripMenuItem });
            openCardDataToolStripMenuItem.Name = "openCardDataToolStripMenuItem";
            openCardDataToolStripMenuItem.Size = new Size(90, 24);
            openCardDataToolStripMenuItem.Text = "Card Data";
            // 
            // loadCardDataFromFilesToolStripMenuItem
            // 
            loadCardDataFromFilesToolStripMenuItem.Name = "loadCardDataFromFilesToolStripMenuItem";
            loadCardDataFromFilesToolStripMenuItem.Size = new Size(250, 26);
            loadCardDataFromFilesToolStripMenuItem.Text = "Load Custom Card Data";
            loadCardDataFromFilesToolStripMenuItem.Click += loadCardDataFromFilesToolStripMenuItem_Click;
            // 
            // resetToDefaultToolStripMenuItem
            // 
            resetToDefaultToolStripMenuItem.Name = "resetToDefaultToolStripMenuItem";
            resetToDefaultToolStripMenuItem.Size = new Size(250, 26);
            resetToDefaultToolStripMenuItem.Text = "Reset to Default";
            resetToDefaultToolStripMenuItem.Click += resetToDefaultToolStripMenuItem_Click;
            // 
            // deckToolStripMenuItem
            // 
            deckToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadDeckFromUnityAssetToolStripMenuItem });
            deckToolStripMenuItem.Name = "deckToolStripMenuItem";
            deckToolStripMenuItem.Size = new Size(62, 24);
            deckToolStripMenuItem.Text = "Decks";
            // 
            // loadDeckFromUnityAssetToolStripMenuItem
            // 
            loadDeckFromUnityAssetToolStripMenuItem.Name = "loadDeckFromUnityAssetToolStripMenuItem";
            loadDeckFromUnityAssetToolStripMenuItem.Size = new Size(289, 26);
            loadDeckFromUnityAssetToolStripMenuItem.Text = "Load Decks from 'data_assets'";
            loadDeckFromUnityAssetToolStripMenuItem.Click += loadDeckFromUnityAssetToolStripMenuItem_Click;
            // 
            // DeckLoader
            // 
            DeckLoader.Filter = "JSON File|*.json|Text File|*.txt|All Files|*.*";
            DeckLoader.FileOk += DeckLoader_FileOk;
            // 
            // DeckSaver
            // 
            DeckSaver.Filter = "JSON File|*.json|Text File|*.txt|All Files|*.*";
            DeckSaver.FileOk += DeckSaver_FileOk;
            // 
            // CardSearch
            // 
            CardSearch.Location = new Point(33, 114);
            CardSearch.Multiline = false;
            CardSearch.Name = "CardSearch";
            CardSearch.ScrollBars = RichTextBoxScrollBars.None;
            CardSearch.Size = new Size(320, 30);
            CardSearch.TabIndex = 2;
            CardSearch.Text = "";
            CardSearch.TextChanged += CardSearch_TextChanged;
            // 
            // SearchList
            // 
            SearchList.DisplayMember = "Name";
            SearchList.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchList.FormattingEnabled = true;
            SearchList.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            SearchList.Location = new Point(79, 152);
            SearchList.Margin = new Padding(25, 3, 3, 3);
            SearchList.Name = "SearchList";
            SearchList.Size = new Size(274, 384);
            SearchList.TabIndex = 3;
            SearchList.ValueMember = "Value";
            SearchList.SelectedIndexChanged += SearchList_SelectedIndexChanged;
            // 
            // SearchCardLabel
            // 
            SearchCardLabel.AutoSize = true;
            SearchCardLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchCardLabel.Location = new Point(33, 91);
            SearchCardLabel.Margin = new Padding(3, 25, 3, 0);
            SearchCardLabel.Name = "SearchCardLabel";
            SearchCardLabel.Size = new Size(152, 20);
            SearchCardLabel.TabIndex = 5;
            SearchCardLabel.Text = "Search Cards To Add";
            // 
            // CardAdder
            // 
            CardAdder.Location = new Point(150, 542);
            CardAdder.Name = "CardAdder";
            CardAdder.Size = new Size(62, 36);
            CardAdder.TabIndex = 6;
            CardAdder.Text = "Add";
            CardAdder.UseVisualStyleBackColor = true;
            CardAdder.Click += CardAdder_Click;
            // 
            // DeckLabel
            // 
            DeckLabel.AutoSize = true;
            DeckLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeckLabel.Location = new Point(366, 129);
            DeckLabel.Name = "DeckLabel";
            DeckLabel.Size = new Size(103, 20);
            DeckLabel.TabIndex = 7;
            DeckLabel.Text = "Cards in Deck";
            // 
            // DeckList
            // 
            DeckList.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DeckList.FormattingEnabled = true;
            DeckList.IntegralHeight = false;
            DeckList.Location = new Point(367, 150);
            DeckList.Margin = new Padding(10, 3, 3, 3);
            DeckList.Name = "DeckList";
            DeckList.Size = new Size(274, 384);
            DeckList.TabIndex = 10;
            DeckList.SelectedIndexChanged += DeckList_SelectedIndexChanged;
            // 
            // CardRemover
            // 
            CardRemover.Font = new Font("Segoe UI", 7F);
            CardRemover.Location = new Point(366, 542);
            CardRemover.Name = "CardRemover";
            CardRemover.Size = new Size(94, 35);
            CardRemover.TabIndex = 9;
            CardRemover.Text = "Remove One";
            CardRemover.UseVisualStyleBackColor = true;
            CardRemover.Click += CardRemover_Click;
            // 
            // CopiesList
            // 
            CopiesList.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopiesList.FormattingEnabled = true;
            CopiesList.IntegralHeight = false;
            CopiesList.Location = new Point(647, 150);
            CopiesList.Margin = new Padding(3, 3, 25, 3);
            CopiesList.Name = "CopiesList";
            CopiesList.SelectionMode = SelectionMode.None;
            CopiesList.Size = new Size(40, 384);
            CopiesList.TabIndex = 13;
            // 
            // CardCount
            // 
            CardCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CardCount.Location = new Point(635, 130);
            CardCount.Name = "CardCount";
            CardCount.Size = new Size(64, 19);
            CardCount.TabIndex = 14;
            CardCount.Text = "×0";
            CardCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CardRemoverAll
            // 
            CardRemoverAll.Font = new Font("Segoe UI", 7F);
            CardRemoverAll.Location = new Point(466, 541);
            CardRemoverAll.Name = "CardRemoverAll";
            CardRemoverAll.Size = new Size(79, 36);
            CardRemoverAll.TabIndex = 15;
            CardRemoverAll.Text = "Remove All";
            CardRemoverAll.UseVisualStyleBackColor = true;
            CardRemoverAll.Click += CardRemoverAll_Click;
            // 
            // CopiesToAdd
            // 
            CopiesToAdd.Location = new Point(97, 548);
            CopiesToAdd.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            CopiesToAdd.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CopiesToAdd.Name = "CopiesToAdd";
            CopiesToAdd.Size = new Size(47, 27);
            CopiesToAdd.TabIndex = 16;
            CopiesToAdd.TextAlign = HorizontalAlignment.Center;
            CopiesToAdd.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // CopiesToAddLabel
            // 
            CopiesToAddLabel.AutoSize = true;
            CopiesToAddLabel.Location = new Point(33, 550);
            CopiesToAddLabel.Name = "CopiesToAddLabel";
            CopiesToAddLabel.Size = new Size(57, 20);
            CopiesToAddLabel.TabIndex = 17;
            CopiesToAddLabel.Text = "Copies:";
            // 
            // SearchListScrollLeft
            // 
            SearchListScrollLeft.Location = new Point(218, 542);
            SearchListScrollLeft.Name = "SearchListScrollLeft";
            SearchListScrollLeft.Size = new Size(36, 36);
            SearchListScrollLeft.TabIndex = 18;
            SearchListScrollLeft.Text = "<";
            SearchListScrollLeft.UseVisualStyleBackColor = true;
            SearchListScrollLeft.Click += SearchListScrollLeft_Click;
            // 
            // SearchListScrollRight
            // 
            SearchListScrollRight.Location = new Point(317, 542);
            SearchListScrollRight.Name = "SearchListScrollRight";
            SearchListScrollRight.Size = new Size(36, 36);
            SearchListScrollRight.TabIndex = 19;
            SearchListScrollRight.Text = ">";
            SearchListScrollRight.UseVisualStyleBackColor = true;
            SearchListScrollRight.Click += SearchListScrollRight_Click;
            // 
            // SearchListPageLabel
            // 
            SearchListPageLabel.Location = new Point(260, 542);
            SearchListPageLabel.Name = "SearchListPageLabel";
            SearchListPageLabel.Size = new Size(51, 36);
            SearchListPageLabel.TabIndex = 20;
            SearchListPageLabel.Text = "0/0";
            SearchListPageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DeckListPageLabel
            // 
            DeckListPageLabel.Location = new Point(593, 541);
            DeckListPageLabel.Name = "DeckListPageLabel";
            DeckListPageLabel.Size = new Size(51, 36);
            DeckListPageLabel.TabIndex = 23;
            DeckListPageLabel.Text = "0/0";
            DeckListPageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DeckListScrollRight
            // 
            DeckListScrollRight.Location = new Point(650, 541);
            DeckListScrollRight.Name = "DeckListScrollRight";
            DeckListScrollRight.Size = new Size(36, 36);
            DeckListScrollRight.TabIndex = 22;
            DeckListScrollRight.Text = ">";
            DeckListScrollRight.UseVisualStyleBackColor = true;
            DeckListScrollRight.Click += DeckListScrollRight_Click;
            // 
            // DeckListScrollLeft
            // 
            DeckListScrollLeft.Location = new Point(551, 541);
            DeckListScrollLeft.Name = "DeckListScrollLeft";
            DeckListScrollLeft.Size = new Size(36, 36);
            DeckListScrollLeft.TabIndex = 21;
            DeckListScrollLeft.Text = "<";
            DeckListScrollLeft.UseVisualStyleBackColor = true;
            DeckListScrollLeft.Click += DeckListScrollLeft_Click;
            // 
            // DeckTypeLabel
            // 
            DeckTypeLabel.AutoSize = true;
            DeckTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeckTypeLabel.Location = new Point(42, 49);
            DeckTypeLabel.Name = "DeckTypeLabel";
            DeckTypeLabel.Size = new Size(46, 20);
            DeckTypeLabel.TabIndex = 24;
            DeckTypeLabel.Text = "Type:";
            // 
            // DeckTypeComboBox
            // 
            DeckTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DeckTypeComboBox.FormattingEnabled = true;
            DeckTypeComboBox.Items.AddRange(new object[] { "Strategy" });
            DeckTypeComboBox.Location = new Point(94, 46);
            DeckTypeComboBox.Name = "DeckTypeComboBox";
            DeckTypeComboBox.Size = new Size(91, 28);
            DeckTypeComboBox.TabIndex = 25;
            DeckTypeComboBox.SelectedIndexChanged += DeckTypeComboBox_SelectedIndexChanged;
            // 
            // DeckNameLabel
            // 
            DeckNameLabel.AutoSize = true;
            DeckNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeckNameLabel.Location = new Point(366, 49);
            DeckNameLabel.Name = "DeckNameLabel";
            DeckNameLabel.Size = new Size(55, 20);
            DeckNameLabel.TabIndex = 26;
            DeckNameLabel.Text = "Name:";
            // 
            // DeckNameTextBox
            // 
            DeckNameTextBox.Location = new Point(429, 46);
            DeckNameTextBox.Name = "DeckNameTextBox";
            DeckNameTextBox.Size = new Size(258, 27);
            DeckNameTextBox.TabIndex = 27;
            // 
            // FactionTypeComboBox
            // 
            FactionTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FactionTypeComboBox.FormattingEnabled = true;
            FactionTypeComboBox.Items.AddRange(new object[] { "Zombies" });
            FactionTypeComboBox.Location = new Point(243, 46);
            FactionTypeComboBox.Name = "FactionTypeComboBox";
            FactionTypeComboBox.Size = new Size(87, 28);
            FactionTypeComboBox.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(195, 49);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 29;
            label1.Text = "Side:";
            // 
            // CardIDList
            // 
            CardIDList.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CardIDList.FormattingEnabled = true;
            CardIDList.IntegralHeight = false;
            CardIDList.Location = new Point(34, 152);
            CardIDList.Margin = new Padding(3, 3, 25, 3);
            CardIDList.Name = "CardIDList";
            CardIDList.SelectionMode = SelectionMode.None;
            CardIDList.Size = new Size(41, 384);
            CardIDList.TabIndex = 30;
            // 
            // CardDataLoader
            // 
            CardDataLoader.FileName = "openFileDialog1";
            CardDataLoader.Filter = "Card Data|*.txt|Card Data|*.json|All Files|*.*";
            CardDataLoader.FileOk += CardDataLoader_FileOk;
            // 
            // CardNameLoader
            // 
            CardNameLoader.FileName = "openFileDialog1";
            CardNameLoader.Filter = "Localized Strings|*.txt|Localized Strings|*.csv|All Files|*.*";
            CardNameLoader.FileOk += CardNameLoader_FileOk;
            // 
            // UnityAssetLoader
            // 
            UnityAssetLoader.FileName = "openFileDialog1";
            UnityAssetLoader.FileOk += UnityAssetLoader_FileOk;
            // 
            // DeckBuilder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 600);
            Controls.Add(CardIDList);
            Controls.Add(label1);
            Controls.Add(FactionTypeComboBox);
            Controls.Add(DeckNameTextBox);
            Controls.Add(DeckNameLabel);
            Controls.Add(DeckTypeComboBox);
            Controls.Add(DeckTypeLabel);
            Controls.Add(DeckListPageLabel);
            Controls.Add(DeckListScrollRight);
            Controls.Add(DeckListScrollLeft);
            Controls.Add(SearchListPageLabel);
            Controls.Add(SearchListScrollRight);
            Controls.Add(SearchListScrollLeft);
            Controls.Add(CopiesToAddLabel);
            Controls.Add(CopiesToAdd);
            Controls.Add(CardRemoverAll);
            Controls.Add(CardCount);
            Controls.Add(CopiesList);
            Controls.Add(DeckList);
            Controls.Add(CardRemover);
            Controls.Add(DeckLabel);
            Controls.Add(CardAdder);
            Controls.Add(SearchCardLabel);
            Controls.Add(SearchList);
            Controls.Add(CardSearch);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "DeckBuilder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PvZH Deck Builder for Mods";
            Load += DeckBuilder_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CopiesToAdd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem filesToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private OpenFileDialog DeckLoader;
        private SaveFileDialog DeckSaver;
        private RichTextBox CardSearch;
        private ListBox SearchList;
        private Label SearchCardLabel;
        private Button CardAdder;
        private Label DeckLabel;
        private ListBox DeckList;
        private Button CardRemover;
        private ListBox CopiesList;
        private Label CardCount;
        private Button CardRemoverAll;
        private NumericUpDown CopiesToAdd;
        private Label CopiesToAddLabel;
        private Button SearchListScrollLeft;
        private Button SearchListScrollRight;
        private Label SearchListPageLabel;
        private Label DeckListPageLabel;
        private Button DeckListScrollRight;
        private Button DeckListScrollLeft;
        private Label DeckTypeLabel;
        private ComboBox DeckTypeComboBox;
        private Label DeckNameLabel;
        private TextBox DeckNameTextBox;
        private ComboBox FactionTypeComboBox;
        private Label label1;
        private ToolStripMenuItem openCardDataToolStripMenuItem;
        private ListBox CardIDList;
        private ToolStripMenuItem loadCardDataFromFilesToolStripMenuItem;
        private OpenFileDialog CardDataLoader;
        private OpenFileDialog CardNameLoader;
        private ToolStripMenuItem resetToDefaultToolStripMenuItem;
        private ToolStripMenuItem deckToolStripMenuItem;
        private ToolStripMenuItem loadDeckFromUnityAssetToolStripMenuItem;
        private OpenFileDialog UnityAssetLoader;
    }
}
