namespace FortuneWheel
{
    partial class mainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.availableFilesListView = new System.Windows.Forms.ListView();
            this.fileNameHeaderLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePathHeaderLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainConfigTable = new System.Windows.Forms.DataGridView();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.backStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPresetStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.undoStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.windowStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.closeStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainConfigTable)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Controls.Add(this.availableFilesListView);
            this.mainPanel.Controls.Add(this.mainConfigTable);
            this.mainPanel.Controls.Add(this.mainMenuStrip);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1224, 653);
            this.mainPanel.TabIndex = 2;
            // 
            // availableFilesListView
            // 
            this.availableFilesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.availableFilesListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.availableFilesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.availableFilesListView.BackColor = System.Drawing.SystemColors.Window;
            this.availableFilesListView.BackgroundImageTiled = true;
            this.availableFilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameHeaderLV,
            this.filePathHeaderLV});
            this.availableFilesListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.availableFilesListView.FullRowSelect = true;
            this.availableFilesListView.HideSelection = false;
            this.availableFilesListView.HoverSelection = true;
            this.availableFilesListView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.availableFilesListView.Location = new System.Drawing.Point(45, 60);
            this.availableFilesListView.Margin = new System.Windows.Forms.Padding(36);
            this.availableFilesListView.MultiSelect = false;
            this.availableFilesListView.Name = "availableFilesListView";
            this.availableFilesListView.Size = new System.Drawing.Size(1134, 548);
            this.availableFilesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.availableFilesListView.TabIndex = 4;
            this.availableFilesListView.TileSize = new System.Drawing.Size(18, 18);
            this.availableFilesListView.UseCompatibleStateImageBehavior = false;
            this.availableFilesListView.View = System.Windows.Forms.View.Details;
            this.availableFilesListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.availableFilesListView_MouseClick);
            // 
            // fileNameHeaderLV
            // 
            this.fileNameHeaderLV.Text = "File Name";
            this.fileNameHeaderLV.Width = 270;
            // 
            // filePathHeaderLV
            // 
            this.filePathHeaderLV.Text = "File Path";
            this.filePathHeaderLV.Width = 999;
            // 
            // mainConfigTable
            // 
            this.mainConfigTable.AllowUserToOrderColumns = true;
            this.mainConfigTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mainConfigTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.mainConfigTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.mainConfigTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainConfigTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Montserrat Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(9);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainConfigTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.mainConfigTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainConfigTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainConfigTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainConfigTable.GridColor = System.Drawing.SystemColors.Window;
            this.mainConfigTable.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.mainConfigTable.Location = new System.Drawing.Point(0, 24);
            this.mainConfigTable.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.mainConfigTable.Name = "mainConfigTable";
            this.mainConfigTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainConfigTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Montserrat Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainConfigTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(7);
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainConfigTable.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.mainConfigTable.Size = new System.Drawing.Size(1224, 629);
            this.mainConfigTable.TabIndex = 0;
            this.mainConfigTable.Visible = false;
            this.mainConfigTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.mainConfigTable_CellBeginEdit);
            this.mainConfigTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainConfigTable_CellEndEdit);
            this.mainConfigTable.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.mainConfigTable_CellValidating);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1224, 24);
            this.mainMenuStrip.TabIndex = 3;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openStripBtn,
            this.saveStripBtn,
            this.saveAsStripBtn,
            this.backStripBtn,
            this.exitStripBtn});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openStripBtn
            // 
            this.openStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("openStripBtn.Image")));
            this.openStripBtn.Name = "openStripBtn";
            this.openStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openStripBtn.Size = new System.Drawing.Size(186, 22);
            this.openStripBtn.Text = "&Open";
            this.openStripBtn.ToolTipText = "Uploads a new config file";
            this.openStripBtn.Click += new System.EventHandler(this.openStripBtn_Click);
            // 
            // saveStripBtn
            // 
            this.saveStripBtn.Enabled = false;
            this.saveStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveStripBtn.Image")));
            this.saveStripBtn.Name = "saveStripBtn";
            this.saveStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveStripBtn.Size = new System.Drawing.Size(186, 22);
            this.saveStripBtn.Text = "&Save";
            this.saveStripBtn.ToolTipText = "Save changes";
            this.saveStripBtn.Click += new System.EventHandler(this.saveStripBtn_Click);
            // 
            // saveAsStripBtn
            // 
            this.saveAsStripBtn.Enabled = false;
            this.saveAsStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveAsStripBtn.Image")));
            this.saveAsStripBtn.Name = "saveAsStripBtn";
            this.saveAsStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsStripBtn.Size = new System.Drawing.Size(186, 22);
            this.saveAsStripBtn.Text = "Save &As";
            this.saveAsStripBtn.ToolTipText = "Save as a file";
            this.saveAsStripBtn.Click += new System.EventHandler(this.saveAsStripBtn_Click);
            // 
            // backStripBtn
            // 
            this.backStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("backStripBtn.Image")));
            this.backStripBtn.Name = "backStripBtn";
            this.backStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.backStripBtn.Size = new System.Drawing.Size(186, 22);
            this.backStripBtn.Text = "&Back&";
            this.backStripBtn.ToolTipText = "Directs to menu page";
            this.backStripBtn.Click += new System.EventHandler(this.backStripBtn_Click);
            // 
            // exitStripBtn
            // 
            this.exitStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitStripBtn.Image")));
            this.exitStripBtn.Name = "exitStripBtn";
            this.exitStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.exitStripBtn.Size = new System.Drawing.Size(186, 22);
            this.exitStripBtn.Text = "Exit";
            this.exitStripBtn.ToolTipText = "Closes application";
            this.exitStripBtn.Click += new System.EventHandler(this.exitStripBtn_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPresetStripBtn,
            this.undoStripBtn});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // editPresetStripBtn
            // 
            this.editPresetStripBtn.Enabled = false;
            this.editPresetStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("editPresetStripBtn.Image")));
            this.editPresetStripBtn.Name = "editPresetStripBtn";
            this.editPresetStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.editPresetStripBtn.Size = new System.Drawing.Size(201, 22);
            this.editPresetStripBtn.Text = "Edit &Preset";
            this.editPresetStripBtn.ToolTipText = "Opens a form to edit presets";
            this.editPresetStripBtn.Click += new System.EventHandler(this.editPresetStripBtn_Click);
            // 
            // undoStripBtn
            // 
            this.undoStripBtn.Enabled = false;
            this.undoStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("undoStripBtn.Image")));
            this.undoStripBtn.Name = "undoStripBtn";
            this.undoStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoStripBtn.Size = new System.Drawing.Size(201, 22);
            this.undoStripBtn.Text = "&Undo";
            this.undoStripBtn.ToolTipText = "Undos changes";
            this.undoStripBtn.Click += new System.EventHandler(this.undoStripBtn_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshStripBtn,
            this.windowStripBtn});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // refreshStripBtn
            // 
            this.refreshStripBtn.Enabled = false;
            this.refreshStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshStripBtn.Image")));
            this.refreshStripBtn.Name = "refreshStripBtn";
            this.refreshStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshStripBtn.Size = new System.Drawing.Size(180, 22);
            this.refreshStripBtn.Text = "&Refresh";
            this.refreshStripBtn.ToolTipText = "Reloads saved data";
            this.refreshStripBtn.Click += new System.EventHandler(this.refreshStripBtn_Click);
            // 
            // windowStripBtn
            // 
            this.windowStripBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenStripBtn,
            this.minimizeStripBtn,
            this.restoreStripBtn,
            this.closeStripBtn});
            this.windowStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("windowStripBtn.Image")));
            this.windowStripBtn.Name = "windowStripBtn";
            this.windowStripBtn.Size = new System.Drawing.Size(180, 22);
            this.windowStripBtn.Text = "&Window";
            // 
            // fullScreenStripBtn
            // 
            this.fullScreenStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("fullScreenStripBtn.Image")));
            this.fullScreenStripBtn.Name = "fullScreenStripBtn";
            this.fullScreenStripBtn.Size = new System.Drawing.Size(180, 22);
            this.fullScreenStripBtn.Text = "&Full Screen";
            this.fullScreenStripBtn.ToolTipText = "Maximizes screen size";
            this.fullScreenStripBtn.Click += new System.EventHandler(this.fullScreenStripBtn_Click);
            // 
            // minimizeStripBtn
            // 
            this.minimizeStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeStripBtn.Image")));
            this.minimizeStripBtn.Name = "minimizeStripBtn";
            this.minimizeStripBtn.Size = new System.Drawing.Size(180, 22);
            this.minimizeStripBtn.Text = "Mi&nimize";
            this.minimizeStripBtn.ToolTipText = "Minimizes screen size";
            this.minimizeStripBtn.Click += new System.EventHandler(this.minimizeStripBtn_Click);
            // 
            // restoreStripBtn
            // 
            this.restoreStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("restoreStripBtn.Image")));
            this.restoreStripBtn.Name = "restoreStripBtn";
            this.restoreStripBtn.Size = new System.Drawing.Size(180, 22);
            this.restoreStripBtn.Text = "&Restore";
            this.restoreStripBtn.ToolTipText = "Turns screen size back to normal";
            this.restoreStripBtn.Click += new System.EventHandler(this.restoreStripBtn_Click);
            // 
            // closeStripBtn
            // 
            this.closeStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeStripBtn.Image")));
            this.closeStripBtn.Name = "closeStripBtn";
            this.closeStripBtn.Size = new System.Drawing.Size(180, 22);
            this.closeStripBtn.Text = "&Close";
            this.closeStripBtn.ToolTipText = "Closes this form";
            this.closeStripBtn.Click += new System.EventHandler(this.closeStripBtn_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1224, 653);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Montserrat Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "mainForm";
            this.Text = "Fortune Wheel Config Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainConfigTable)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openStripBtn;
        private System.Windows.Forms.ToolStripMenuItem saveStripBtn;
        private System.Windows.Forms.ToolStripMenuItem saveAsStripBtn;
        private System.Windows.Forms.ToolStripMenuItem exitStripBtn;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPresetStripBtn;
        private System.Windows.Forms.ToolStripMenuItem undoStripBtn;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshStripBtn;
        private System.Windows.Forms.ToolStripMenuItem windowStripBtn;
        private System.Windows.Forms.ToolStripMenuItem closeStripBtn;
        private System.Windows.Forms.ToolStripMenuItem fullScreenStripBtn;
        private System.Windows.Forms.ToolStripMenuItem minimizeStripBtn;
        private System.Windows.Forms.ToolStripMenuItem restoreStripBtn;
        private System.Windows.Forms.ListView availableFilesListView;
        private System.Windows.Forms.ColumnHeader fileNameHeaderLV;
        private System.Windows.Forms.ColumnHeader filePathHeaderLV;
        private System.Windows.Forms.ToolStripMenuItem backStripBtn;
        private System.Windows.Forms.DataGridView mainConfigTable;
    }
}

