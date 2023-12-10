namespace FortuneWheel
{
    partial class presetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(presetForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.presetMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.backStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoStripBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPresetTable = new System.Windows.Forms.DataGridView();
            this.presetMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPresetTable)).BeginInit();
            this.SuspendLayout();
            // 
            // presetMenuStrip
            // 
            this.presetMenuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.presetMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.presetMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.presetMenuStrip.Name = "presetMenuStrip";
            this.presetMenuStrip.Size = new System.Drawing.Size(912, 24);
            this.presetMenuStrip.TabIndex = 3;
            this.presetMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveStripBtn,
            this.backStripBtn,
            this.exitStripBtn});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveStripBtn
            // 
            this.saveStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveStripBtn.Image")));
            this.saveStripBtn.Name = "saveStripBtn";
            this.saveStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveStripBtn.Size = new System.Drawing.Size(180, 22);
            this.saveStripBtn.Text = "&Save";
            this.saveStripBtn.ToolTipText = "Save changes";
            this.saveStripBtn.Click += new System.EventHandler(this.saveStripBtn_Click);
            // 
            // backStripBtn
            // 
            this.backStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("backStripBtn.Image")));
            this.backStripBtn.Name = "backStripBtn";
            this.backStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.backStripBtn.Size = new System.Drawing.Size(180, 22);
            this.backStripBtn.Text = "&Back";
            this.backStripBtn.ToolTipText = "Closes this form";
            this.backStripBtn.Click += new System.EventHandler(this.backStripBtn_Click);
            // 
            // exitStripBtn
            // 
            this.exitStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitStripBtn.Image")));
            this.exitStripBtn.Name = "exitStripBtn";
            this.exitStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.exitStripBtn.Size = new System.Drawing.Size(180, 22);
            this.exitStripBtn.Text = "&Exit";
            this.exitStripBtn.ToolTipText = "Closes application";
            this.exitStripBtn.Click += new System.EventHandler(this.exitStripBtn_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoStripBtn});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoStripBtn
            // 
            this.undoStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("undoStripBtn.Image")));
            this.undoStripBtn.Name = "undoStripBtn";
            this.undoStripBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoStripBtn.Size = new System.Drawing.Size(180, 22);
            this.undoStripBtn.Text = "&Undo";
            this.undoStripBtn.ToolTipText = "Undos changes";
            this.undoStripBtn.Click += new System.EventHandler(this.undoStripBtn_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.ToolTipText = "Reloads saved data";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.restoreToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.windowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("windowToolStripMenuItem.Image")));
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fullScreenToolStripMenuItem.Image")));
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fullScreenToolStripMenuItem.Text = "&Full Screen";
            this.fullScreenToolStripMenuItem.ToolTipText = "Maximizes screen size";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("minimizeToolStripMenuItem.Image")));
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.minimizeToolStripMenuItem.Text = "Mi&nimize";
            this.minimizeToolStripMenuItem.ToolTipText = "Minimizes screen size";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restoreToolStripMenuItem.Image")));
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.restoreToolStripMenuItem.Text = "&Restore";
            this.restoreToolStripMenuItem.ToolTipText = "Turns screen size back to normal";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.ToolTipText = "Closes this form";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // mainPresetTable
            // 
            this.mainPresetTable.AllowUserToAddRows = false;
            this.mainPresetTable.AllowUserToDeleteRows = false;
            this.mainPresetTable.AllowUserToOrderColumns = true;
            this.mainPresetTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPresetTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mainPresetTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.mainPresetTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.mainPresetTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainPresetTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Montserrat Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(9);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainPresetTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.mainPresetTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainPresetTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainPresetTable.GridColor = System.Drawing.SystemColors.Window;
            this.mainPresetTable.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.mainPresetTable.Location = new System.Drawing.Point(0, 24);
            this.mainPresetTable.Margin = new System.Windows.Forms.Padding(0);
            this.mainPresetTable.Name = "mainPresetTable";
            this.mainPresetTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainPresetTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Montserrat Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainPresetTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(7);
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainPresetTable.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.mainPresetTable.Size = new System.Drawing.Size(912, 492);
            this.mainPresetTable.TabIndex = 4;
            this.mainPresetTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.mainPresetTable_CellBeginEdit);
            this.mainPresetTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainPresetTable_CellEndEdit);
            this.mainPresetTable.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.mainPresetTable_CellValidating);
            // 
            // presetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(912, 516);
            this.Controls.Add(this.mainPresetTable);
            this.Controls.Add(this.presetMenuStrip);
            this.Font = new System.Drawing.Font("Montserrat Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.presetMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "presetForm";
            this.Text = "Edit Preset";
            this.presetMenuStrip.ResumeLayout(false);
            this.presetMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPresetTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip presetMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStripBtn;
        private System.Windows.Forms.ToolStripMenuItem backStripBtn;
        private System.Windows.Forms.ToolStripMenuItem exitStripBtn;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoStripBtn;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.DataGridView mainPresetTable;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}