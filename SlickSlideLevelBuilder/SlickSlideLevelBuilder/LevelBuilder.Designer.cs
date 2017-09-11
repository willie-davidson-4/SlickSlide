namespace SlickSlideLevelBuilder
{
	partial class LevelBuilder
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
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemSaveLevel = new System.Windows.Forms.ToolStripMenuItem();
			this.clearLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemAddRow = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemAddColumn = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemRemoveRow = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemRemoveColumn = new System.Windows.Forms.ToolStripMenuItem();
			this.shiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemShiftRight = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemShiftDown = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemShiftLeft = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemShiftUp = new System.Windows.Forms.ToolStripMenuItem();
			this.solveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.shiftToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(284, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSaveLevel,
            this.clearLevelToolStripMenuItem,
            this.solveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// toolStripMenuItemSaveLevel
			// 
			this.toolStripMenuItemSaveLevel.Name = "toolStripMenuItemSaveLevel";
			this.toolStripMenuItemSaveLevel.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItemSaveLevel.Text = "Save";
			this.toolStripMenuItemSaveLevel.Click += new System.EventHandler(this.toolStripMenuItemSaveLevel_Click);
			// 
			// clearLevelToolStripMenuItem
			// 
			this.clearLevelToolStripMenuItem.Name = "clearLevelToolStripMenuItem";
			this.clearLevelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.clearLevelToolStripMenuItem.Text = "Clear Level";
			this.clearLevelToolStripMenuItem.Click += new System.EventHandler(this.clearLevelToolStripMenuItem_Click);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddRow,
            this.toolStripMenuItemAddColumn});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.addToolStripMenuItem.Text = "Add";
			// 
			// toolStripMenuItemAddRow
			// 
			this.toolStripMenuItemAddRow.Name = "toolStripMenuItemAddRow";
			this.toolStripMenuItemAddRow.Size = new System.Drawing.Size(117, 22);
			this.toolStripMenuItemAddRow.Text = "Row";
			this.toolStripMenuItemAddRow.Click += new System.EventHandler(this.toolStripMenuItemAddRow_Click);
			// 
			// toolStripMenuItemAddColumn
			// 
			this.toolStripMenuItemAddColumn.Name = "toolStripMenuItemAddColumn";
			this.toolStripMenuItemAddColumn.Size = new System.Drawing.Size(117, 22);
			this.toolStripMenuItemAddColumn.Text = "Column";
			this.toolStripMenuItemAddColumn.Click += new System.EventHandler(this.toolStripMenuItemAddColumn_Click);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRemoveRow,
            this.toolStripMenuItemRemoveColumn});
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
			this.removeToolStripMenuItem.Text = "Remove";
			// 
			// toolStripMenuItemRemoveRow
			// 
			this.toolStripMenuItemRemoveRow.Name = "toolStripMenuItemRemoveRow";
			this.toolStripMenuItemRemoveRow.Size = new System.Drawing.Size(117, 22);
			this.toolStripMenuItemRemoveRow.Text = "Row";
			this.toolStripMenuItemRemoveRow.Click += new System.EventHandler(this.toolStripMenuItemRemoveRow_Click);
			// 
			// toolStripMenuItemRemoveColumn
			// 
			this.toolStripMenuItemRemoveColumn.Name = "toolStripMenuItemRemoveColumn";
			this.toolStripMenuItemRemoveColumn.Size = new System.Drawing.Size(117, 22);
			this.toolStripMenuItemRemoveColumn.Text = "Column";
			this.toolStripMenuItemRemoveColumn.Click += new System.EventHandler(this.toolStripMenuItemRemoveColumn_Click);
			// 
			// shiftToolStripMenuItem
			// 
			this.shiftToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShiftRight,
            this.toolStripMenuItemShiftDown,
            this.toolStripMenuItemShiftLeft,
            this.toolStripMenuItemShiftUp});
			this.shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
			this.shiftToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.shiftToolStripMenuItem.Text = "Shift";
			// 
			// toolStripMenuItemShiftRight
			// 
			this.toolStripMenuItemShiftRight.Name = "toolStripMenuItemShiftRight";
			this.toolStripMenuItemShiftRight.Size = new System.Drawing.Size(105, 22);
			this.toolStripMenuItemShiftRight.Text = "Right";
			this.toolStripMenuItemShiftRight.Click += new System.EventHandler(this.toolStripMenuItemShiftRight_Click);
			// 
			// toolStripMenuItemShiftDown
			// 
			this.toolStripMenuItemShiftDown.Name = "toolStripMenuItemShiftDown";
			this.toolStripMenuItemShiftDown.Size = new System.Drawing.Size(105, 22);
			this.toolStripMenuItemShiftDown.Text = "Down";
			this.toolStripMenuItemShiftDown.Click += new System.EventHandler(this.toolStripMenuItemShiftDown_Click);
			// 
			// toolStripMenuItemShiftLeft
			// 
			this.toolStripMenuItemShiftLeft.Name = "toolStripMenuItemShiftLeft";
			this.toolStripMenuItemShiftLeft.Size = new System.Drawing.Size(105, 22);
			this.toolStripMenuItemShiftLeft.Text = "Left";
			this.toolStripMenuItemShiftLeft.Click += new System.EventHandler(this.toolStripMenuItemShiftLeft_Click);
			// 
			// toolStripMenuItemShiftUp
			// 
			this.toolStripMenuItemShiftUp.Name = "toolStripMenuItemShiftUp";
			this.toolStripMenuItemShiftUp.Size = new System.Drawing.Size(105, 22);
			this.toolStripMenuItemShiftUp.Text = "Up";
			this.toolStripMenuItemShiftUp.Click += new System.EventHandler(this.toolStripMenuItemShiftUp_Click);
			// 
			// solveToolStripMenuItem
			// 
			this.solveToolStripMenuItem.Name = "solveToolStripMenuItem";
			this.solveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.solveToolStripMenuItem.Text = "Solve";
			this.solveToolStripMenuItem.Click += new System.EventHandler(this.solveToolStripMenuItem_Click);
			// 
			// LevelBuilder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "LevelBuilder";
			this.Text = "LevelBuilder";
			this.Load += new System.EventHandler(this.LevelBuilder_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddRow;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddColumn;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveRow;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveColumn;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveLevel;
		private System.Windows.Forms.ToolStripMenuItem shiftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShiftRight;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShiftDown;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShiftLeft;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShiftUp;
		private System.Windows.Forms.ToolStripMenuItem clearLevelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem solveToolStripMenuItem;
	}
}