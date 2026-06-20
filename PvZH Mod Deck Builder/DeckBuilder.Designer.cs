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
            loadBundleToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            openCardDataToolStripMenuItem = new ToolStripMenuItem();
            loadCardDataFromFilesToolStripMenuItem = new ToolStripMenuItem();
            resetToDefaultToolStripMenuItem = new ToolStripMenuItem();
            DeckLoader = new OpenFileDialog();
            DeckSaver = new SaveFileDialog();
            CardSearch = new RichTextBox();
            CardSearchList = new ListBox();
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
            CardSearchScrollLeft = new Button();
            CardSearchScrollRight = new Button();
            CardSearchPageLabel = new Label();
            DeckListPageLabel = new Label();
            DeckListScrollRight = new Button();
            DeckListScrollLeft = new Button();
            DeckTypeLabel = new Label();
            DeckTypeComboBox = new ComboBox();
            DeckNameLabel = new Label();
            DeckNameTextBox = new TextBox();
            FactionTypeComboBox = new ComboBox();
            FactionLabel = new Label();
            CardIDList = new ListBox();
            UnityAssetLoader = new OpenFileDialog();
            CardFolderLoader = new FolderBrowserDialog();
            DeckSearchList = new ListBox();
            DeckSearch = new RichTextBox();
            DeckSearchPageLabel = new Label();
            DeckSearchScrollRight = new Button();
            DeckSearchScrollLeft = new Button();
            DeckSearchLabel = new Label();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CopiesToAdd).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { filesToolStripMenuItem, openCardDataToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1036, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            filesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, loadToolStripMenuItem, loadBundleToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            filesToolStripMenuItem.Size = new Size(52, 24);
            filesToolStripMenuItem.Text = "Files";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(264, 26);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click_1;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadToolStripMenuItem.Size = new Size(264, 26);
            loadToolStripMenuItem.Text = "Load JSON";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // loadBundleToolStripMenuItem
            // 
            loadBundleToolStripMenuItem.Name = "loadBundleToolStripMenuItem";
            loadBundleToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.L;
            loadBundleToolStripMenuItem.Size = new Size(264, 26);
            loadBundleToolStripMenuItem.Text = "Load Bundle";
            loadBundleToolStripMenuItem.Click += loadBundleToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(264, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(264, 26);
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
            CardSearch.Location = new Point(23, 114);
            CardSearch.Multiline = false;
            CardSearch.Name = "CardSearch";
            CardSearch.ScrollBars = RichTextBoxScrollBars.None;
            CardSearch.Size = new Size(320, 30);
            CardSearch.TabIndex = 2;
            CardSearch.Text = "";
            CardSearch.TextChanged += CardSearch_TextChanged;
            // 
            // CardSearchList
            // 
            CardSearchList.DisplayMember = "Name";
            CardSearchList.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CardSearchList.FormattingEnabled = true;
            CardSearchList.Location = new Point(69, 152);
            CardSearchList.Margin = new Padding(25, 3, 3, 3);
            CardSearchList.Name = "CardSearchList";
            CardSearchList.Size = new Size(274, 384);
            CardSearchList.TabIndex = 3;
            CardSearchList.ValueMember = "Value";
            CardSearchList.SelectedIndexChanged += CardSearchList_SelectedIndexChanged;
            // 
            // SearchCardLabel
            // 
            SearchCardLabel.AutoSize = true;
            SearchCardLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchCardLabel.Location = new Point(23, 91);
            SearchCardLabel.Margin = new Padding(3, 25, 3, 0);
            SearchCardLabel.Name = "SearchCardLabel";
            SearchCardLabel.Size = new Size(152, 20);
            SearchCardLabel.TabIndex = 5;
            SearchCardLabel.Text = "Search Cards To Add";
            // 
            // CardAdder
            // 
            CardAdder.Location = new Point(140, 542);
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
            DeckLabel.Location = new Point(356, 129);
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
            DeckList.Location = new Point(357, 150);
            DeckList.Margin = new Padding(10, 3, 3, 3);
            DeckList.Name = "DeckList";
            DeckList.Size = new Size(274, 384);
            DeckList.TabIndex = 10;
            DeckList.SelectedIndexChanged += DeckList_SelectedIndexChanged;
            // 
            // CardRemover
            // 
            CardRemover.Font = new Font("Segoe UI", 7F);
            CardRemover.Location = new Point(356, 542);
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
            CopiesList.Location = new Point(637, 150);
            CopiesList.Margin = new Padding(3, 3, 25, 3);
            CopiesList.Name = "CopiesList";
            CopiesList.SelectionMode = SelectionMode.None;
            CopiesList.Size = new Size(40, 384);
            CopiesList.TabIndex = 13;
            // 
            // CardCount
            // 
            CardCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CardCount.Location = new Point(625, 130);
            CardCount.Name = "CardCount";
            CardCount.Size = new Size(64, 19);
            CardCount.TabIndex = 14;
            CardCount.Text = "×0";
            CardCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CardRemoverAll
            // 
            CardRemoverAll.Font = new Font("Segoe UI", 7F);
            CardRemoverAll.Location = new Point(456, 541);
            CardRemoverAll.Name = "CardRemoverAll";
            CardRemoverAll.Size = new Size(79, 36);
            CardRemoverAll.TabIndex = 15;
            CardRemoverAll.Text = "Remove All";
            CardRemoverAll.UseVisualStyleBackColor = true;
            CardRemoverAll.Click += CardRemoverAll_Click;
            // 
            // CopiesToAdd
            // 
            CopiesToAdd.Location = new Point(87, 548);
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
            CopiesToAddLabel.Location = new Point(23, 550);
            CopiesToAddLabel.Name = "CopiesToAddLabel";
            CopiesToAddLabel.Size = new Size(57, 20);
            CopiesToAddLabel.TabIndex = 17;
            CopiesToAddLabel.Text = "Copies:";
            // 
            // CardSearchScrollLeft
            // 
            CardSearchScrollLeft.Location = new Point(208, 542);
            CardSearchScrollLeft.Name = "CardSearchScrollLeft";
            CardSearchScrollLeft.Size = new Size(36, 36);
            CardSearchScrollLeft.TabIndex = 18;
            CardSearchScrollLeft.Text = "<";
            CardSearchScrollLeft.UseVisualStyleBackColor = true;
            CardSearchScrollLeft.Click += CardSearchListScrollLeft_Click;
            // 
            // CardSearchScrollRight
            // 
            CardSearchScrollRight.Location = new Point(307, 542);
            CardSearchScrollRight.Name = "CardSearchScrollRight";
            CardSearchScrollRight.Size = new Size(36, 36);
            CardSearchScrollRight.TabIndex = 19;
            CardSearchScrollRight.Text = ">";
            CardSearchScrollRight.UseVisualStyleBackColor = true;
            CardSearchScrollRight.Click += CardSearchScrollRight_Click;
            // 
            // CardSearchPageLabel
            // 
            CardSearchPageLabel.Location = new Point(250, 542);
            CardSearchPageLabel.Name = "CardSearchPageLabel";
            CardSearchPageLabel.Size = new Size(51, 36);
            CardSearchPageLabel.TabIndex = 20;
            CardSearchPageLabel.Text = "0/0";
            CardSearchPageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DeckListPageLabel
            // 
            DeckListPageLabel.Location = new Point(583, 541);
            DeckListPageLabel.Name = "DeckListPageLabel";
            DeckListPageLabel.Size = new Size(51, 36);
            DeckListPageLabel.TabIndex = 23;
            DeckListPageLabel.Text = "0/0";
            DeckListPageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DeckListScrollRight
            // 
            DeckListScrollRight.Location = new Point(640, 541);
            DeckListScrollRight.Name = "DeckListScrollRight";
            DeckListScrollRight.Size = new Size(36, 36);
            DeckListScrollRight.TabIndex = 22;
            DeckListScrollRight.Text = ">";
            DeckListScrollRight.UseVisualStyleBackColor = true;
            DeckListScrollRight.Click += DeckListScrollRight_Click;
            // 
            // DeckListScrollLeft
            // 
            DeckListScrollLeft.Location = new Point(541, 541);
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
            DeckTypeLabel.Location = new Point(32, 49);
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
            DeckTypeComboBox.Location = new Point(84, 46);
            DeckTypeComboBox.Name = "DeckTypeComboBox";
            DeckTypeComboBox.Size = new Size(91, 28);
            DeckTypeComboBox.TabIndex = 25;
            DeckTypeComboBox.SelectedIndexChanged += DeckTypeComboBox_SelectedIndexChanged;
            // 
            // DeckNameLabel
            // 
            DeckNameLabel.AutoSize = true;
            DeckNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeckNameLabel.Location = new Point(356, 49);
            DeckNameLabel.Name = "DeckNameLabel";
            DeckNameLabel.Size = new Size(55, 20);
            DeckNameLabel.TabIndex = 26;
            DeckNameLabel.Text = "Name:";
            // 
            // DeckNameTextBox
            // 
            DeckNameTextBox.Location = new Point(419, 46);
            DeckNameTextBox.Name = "DeckNameTextBox";
            DeckNameTextBox.Size = new Size(258, 27);
            DeckNameTextBox.TabIndex = 27;
            // 
            // FactionTypeComboBox
            // 
            FactionTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FactionTypeComboBox.FormattingEnabled = true;
            FactionTypeComboBox.Items.AddRange(new object[] { "Zombies" });
            FactionTypeComboBox.Location = new Point(233, 46);
            FactionTypeComboBox.Name = "FactionTypeComboBox";
            FactionTypeComboBox.Size = new Size(87, 28);
            FactionTypeComboBox.TabIndex = 28;
            // 
            // FactionLabel
            // 
            FactionLabel.AutoSize = true;
            FactionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FactionLabel.Location = new Point(185, 49);
            FactionLabel.Name = "FactionLabel";
            FactionLabel.Size = new Size(42, 20);
            FactionLabel.TabIndex = 29;
            FactionLabel.Text = "Side:";
            // 
            // CardIDList
            // 
            CardIDList.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CardIDList.FormattingEnabled = true;
            CardIDList.IntegralHeight = false;
            CardIDList.Location = new Point(24, 152);
            CardIDList.Margin = new Padding(3, 3, 25, 3);
            CardIDList.Name = "CardIDList";
            CardIDList.SelectionMode = SelectionMode.None;
            CardIDList.Size = new Size(41, 384);
            CardIDList.TabIndex = 30;
            // 
            // UnityAssetLoader
            // 
            UnityAssetLoader.FileName = "openFileDialog1";
            UnityAssetLoader.FileOk += UnityAssetLoader_FileOk;
            // 
            // DeckSearchList
            // 
            DeckSearchList.DisplayMember = "Name";
            DeckSearchList.Enabled = false;
            DeckSearchList.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DeckSearchList.FormattingEnabled = true;
            DeckSearchList.Location = new Point(694, 150);
            DeckSearchList.Margin = new Padding(25, 3, 3, 3);
            DeckSearchList.Name = "DeckSearchList";
            DeckSearchList.Size = new Size(320, 384);
            DeckSearchList.TabIndex = 31;
            DeckSearchList.ValueMember = "Value";
            DeckSearchList.SelectedIndexChanged += DeckSearchList_SelectedIndexChanged;
            // 
            // DeckSearch
            // 
            DeckSearch.Enabled = false;
            DeckSearch.Location = new Point(694, 114);
            DeckSearch.Multiline = false;
            DeckSearch.Name = "DeckSearch";
            DeckSearch.ScrollBars = RichTextBoxScrollBars.None;
            DeckSearch.Size = new Size(320, 30);
            DeckSearch.TabIndex = 32;
            DeckSearch.Text = "";
            DeckSearch.TextChanged += DeckSearch_TextChanged;
            // 
            // DeckSearchPageLabel
            // 
            DeckSearchPageLabel.Location = new Point(827, 539);
            DeckSearchPageLabel.Name = "DeckSearchPageLabel";
            DeckSearchPageLabel.Size = new Size(51, 36);
            DeckSearchPageLabel.TabIndex = 35;
            DeckSearchPageLabel.Text = "0/0";
            DeckSearchPageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DeckSearchScrollRight
            // 
            DeckSearchScrollRight.Location = new Point(884, 539);
            DeckSearchScrollRight.Name = "DeckSearchScrollRight";
            DeckSearchScrollRight.Size = new Size(36, 36);
            DeckSearchScrollRight.TabIndex = 34;
            DeckSearchScrollRight.Text = ">";
            DeckSearchScrollRight.UseVisualStyleBackColor = true;
            DeckSearchScrollRight.Click += DeckSearchScrollRight_Click;
            // 
            // DeckSearchScrollLeft
            // 
            DeckSearchScrollLeft.Location = new Point(785, 539);
            DeckSearchScrollLeft.Name = "DeckSearchScrollLeft";
            DeckSearchScrollLeft.Size = new Size(36, 36);
            DeckSearchScrollLeft.TabIndex = 33;
            DeckSearchScrollLeft.Text = "<";
            DeckSearchScrollLeft.UseVisualStyleBackColor = true;
            DeckSearchScrollLeft.Click += DeckSearchScrollLeft_Click;
            // 
            // DeckSearchLabel
            // 
            DeckSearchLabel.AutoSize = true;
            DeckSearchLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeckSearchLabel.Location = new Point(694, 91);
            DeckSearchLabel.Margin = new Padding(3, 25, 3, 0);
            DeckSearchLabel.Name = "DeckSearchLabel";
            DeckSearchLabel.Size = new Size(143, 20);
            DeckSearchLabel.TabIndex = 36;
            DeckSearchLabel.Text = "Search Deck to Edit";
            // 
            // DeckBuilder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 600);
            Controls.Add(DeckSearchLabel);
            Controls.Add(DeckSearchPageLabel);
            Controls.Add(DeckSearchScrollRight);
            Controls.Add(DeckSearchScrollLeft);
            Controls.Add(DeckSearch);
            Controls.Add(DeckSearchList);
            Controls.Add(CardIDList);
            Controls.Add(FactionLabel);
            Controls.Add(FactionTypeComboBox);
            Controls.Add(DeckNameTextBox);
            Controls.Add(DeckNameLabel);
            Controls.Add(DeckTypeComboBox);
            Controls.Add(DeckTypeLabel);
            Controls.Add(DeckListPageLabel);
            Controls.Add(DeckListScrollRight);
            Controls.Add(DeckListScrollLeft);
            Controls.Add(CardSearchPageLabel);
            Controls.Add(CardSearchScrollRight);
            Controls.Add(CardSearchScrollLeft);
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
            Controls.Add(CardSearchList);
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
        private ListBox CardSearchList;
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
        private Button CardSearchScrollLeft;
        private Button CardSearchScrollRight;
        private Label CardSearchPageLabel;
        private Label DeckListPageLabel;
        private Button DeckListScrollRight;
        private Button DeckListScrollLeft;
        private Label DeckTypeLabel;
        private ComboBox DeckTypeComboBox;
        private Label DeckNameLabel;
        private TextBox DeckNameTextBox;
        private ComboBox FactionTypeComboBox;
        private Label FactionLabel;
        private ToolStripMenuItem openCardDataToolStripMenuItem;
        private ListBox CardIDList;
        private ToolStripMenuItem loadCardDataFromFilesToolStripMenuItem;
        private OpenFileDialog CardDataLoader;
        private OpenFileDialog CardNameLoader;
        private ToolStripMenuItem resetToDefaultToolStripMenuItem;
        private OpenFileDialog UnityAssetLoader;
        private ToolStripMenuItem loadBundleToolStripMenuItem;
        private FolderBrowserDialog CardFolderLoader;
        private ListBox DeckSearchList;
        private RichTextBox DeckSearch;
        private Label DeckSearchPageLabel;
        private Button DeckSearchScrollRight;
        private Button DeckSearchScrollLeft;
        private Label DeckSearchLabel;
    }
}
