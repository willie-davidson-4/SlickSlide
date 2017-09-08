namespace SlickSlideLevelBuilder
{
	partial class LevelConfig
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
			this.buttonNewLevel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBoxStartTile = new System.Windows.Forms.PictureBox();
			this.pictureBoxSlideTile = new System.Windows.Forms.PictureBox();
			this.pictureBoxEndTile = new System.Windows.Forms.PictureBox();
			this.pictureBoxBlockTile = new System.Windows.Forms.PictureBox();
			this.pictureBoxStepTile = new System.Windows.Forms.PictureBox();
			this.pictureBoxCurrentTile = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBoxEmpty = new System.Windows.Forms.PictureBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStartTile)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlideTile)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxEndTile)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockTile)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStepTile)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentTile)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmpty)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonNewLevel
			// 
			this.buttonNewLevel.Location = new System.Drawing.Point(6, 71);
			this.buttonNewLevel.Name = "buttonNewLevel";
			this.buttonNewLevel.Size = new System.Drawing.Size(187, 23);
			this.buttonNewLevel.TabIndex = 0;
			this.buttonNewLevel.Text = "New Level";
			this.buttonNewLevel.UseVisualStyleBackColor = true;
			this.buttonNewLevel.Click += new System.EventHandler(this.buttonNewLevel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numericUpDownColumns);
			this.groupBox1.Controls.Add(this.numericUpDownRows);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.buttonNewLevel);
			this.groupBox1.Location = new System.Drawing.Point(12, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(199, 100);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Level Setup";
			// 
			// numericUpDownColumns
			// 
			this.numericUpDownColumns.Location = new System.Drawing.Point(59, 19);
			this.numericUpDownColumns.Name = "numericUpDownColumns";
			this.numericUpDownColumns.Size = new System.Drawing.Size(134, 20);
			this.numericUpDownColumns.TabIndex = 4;
			// 
			// numericUpDownRows
			// 
			this.numericUpDownRows.Location = new System.Drawing.Point(59, 45);
			this.numericUpDownRows.Name = "numericUpDownRows";
			this.numericUpDownRows.Size = new System.Drawing.Size(134, 20);
			this.numericUpDownRows.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Columns";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Rows";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.pictureBoxStartTile);
			this.groupBox2.Controls.Add(this.pictureBoxEmpty);
			this.groupBox2.Controls.Add(this.pictureBoxSlideTile);
			this.groupBox2.Controls.Add(this.pictureBoxEndTile);
			this.groupBox2.Controls.Add(this.pictureBoxBlockTile);
			this.groupBox2.Controls.Add(this.pictureBoxStepTile);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(12, 133);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(199, 304);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tiles (LeftClick to edit, RightClick to select)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(12, 212);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(26, 13);
			this.label7.TabIndex = 1;
			this.label7.Text = "End";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(107, 117);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Start";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(12, 117);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Block";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(107, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Slide";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Step";
			// 
			// pictureBoxStartTile
			// 
			this.pictureBoxStartTile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxStartTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxStartTile.Location = new System.Drawing.Point(104, 114);
			this.pictureBoxStartTile.Name = "pictureBoxStartTile";
			this.pictureBoxStartTile.Size = new System.Drawing.Size(89, 89);
			this.pictureBoxStartTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxStartTile.TabIndex = 0;
			this.pictureBoxStartTile.TabStop = false;
			this.pictureBoxStartTile.Click += new System.EventHandler(this.pictureBoxCommon_Click);
			// 
			// pictureBoxSlideTile
			// 
			this.pictureBoxSlideTile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSlideTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxSlideTile.Location = new System.Drawing.Point(104, 19);
			this.pictureBoxSlideTile.Name = "pictureBoxSlideTile";
			this.pictureBoxSlideTile.Size = new System.Drawing.Size(89, 89);
			this.pictureBoxSlideTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSlideTile.TabIndex = 0;
			this.pictureBoxSlideTile.TabStop = false;
			this.pictureBoxSlideTile.Click += new System.EventHandler(this.pictureBoxCommon_Click);
			// 
			// pictureBoxEndTile
			// 
			this.pictureBoxEndTile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxEndTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxEndTile.Location = new System.Drawing.Point(9, 209);
			this.pictureBoxEndTile.Name = "pictureBoxEndTile";
			this.pictureBoxEndTile.Size = new System.Drawing.Size(89, 89);
			this.pictureBoxEndTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxEndTile.TabIndex = 0;
			this.pictureBoxEndTile.TabStop = false;
			this.pictureBoxEndTile.Click += new System.EventHandler(this.pictureBoxCommon_Click);
			// 
			// pictureBoxBlockTile
			// 
			this.pictureBoxBlockTile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxBlockTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxBlockTile.Location = new System.Drawing.Point(9, 114);
			this.pictureBoxBlockTile.Name = "pictureBoxBlockTile";
			this.pictureBoxBlockTile.Size = new System.Drawing.Size(89, 89);
			this.pictureBoxBlockTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxBlockTile.TabIndex = 0;
			this.pictureBoxBlockTile.TabStop = false;
			this.pictureBoxBlockTile.Click += new System.EventHandler(this.pictureBoxCommon_Click);
			// 
			// pictureBoxStepTile
			// 
			this.pictureBoxStepTile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxStepTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxStepTile.Location = new System.Drawing.Point(9, 19);
			this.pictureBoxStepTile.Name = "pictureBoxStepTile";
			this.pictureBoxStepTile.Size = new System.Drawing.Size(89, 89);
			this.pictureBoxStepTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxStepTile.TabIndex = 0;
			this.pictureBoxStepTile.TabStop = false;
			this.pictureBoxStepTile.Click += new System.EventHandler(this.pictureBoxCommon_Click);
			// 
			// pictureBoxCurrentTile
			// 
			this.pictureBoxCurrentTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxCurrentTile.Location = new System.Drawing.Point(12, 444);
			this.pictureBoxCurrentTile.Name = "pictureBoxCurrentTile";
			this.pictureBoxCurrentTile.Size = new System.Drawing.Size(199, 199);
			this.pictureBoxCurrentTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxCurrentTile.TabIndex = 3;
			this.pictureBoxCurrentTile.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(223, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadLevelToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadLevelToolStripMenuItem
			// 
			this.loadLevelToolStripMenuItem.Name = "loadLevelToolStripMenuItem";
			this.loadLevelToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.loadLevelToolStripMenuItem.Text = "Load Level";
			// 
			// pictureBoxEmpty
			// 
			this.pictureBoxEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxEmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxEmpty.Location = new System.Drawing.Point(104, 209);
			this.pictureBoxEmpty.Name = "pictureBoxEmpty";
			this.pictureBoxEmpty.Size = new System.Drawing.Size(89, 89);
			this.pictureBoxEmpty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxEmpty.TabIndex = 0;
			this.pictureBoxEmpty.TabStop = false;
			this.pictureBoxEmpty.Click += new System.EventHandler(this.pictureBoxCommon_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(107, 212);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(36, 13);
			this.label8.TabIndex = 1;
			this.label8.Text = "Empty";
			this.label8.Click += new System.EventHandler(this.pictureBoxCommon_Click);
			// 
			// LevelConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(223, 655);
			this.Controls.Add(this.pictureBoxCurrentTile);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "LevelConfig";
			this.Text = "LevelConfig";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStartTile)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlideTile)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxEndTile)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlockTile)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStepTile)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentTile)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmpty)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonNewLevel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numericUpDownColumns;
		private System.Windows.Forms.NumericUpDown numericUpDownRows;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox pictureBoxStepTile;
		private System.Windows.Forms.PictureBox pictureBoxStartTile;
		private System.Windows.Forms.PictureBox pictureBoxSlideTile;
		private System.Windows.Forms.PictureBox pictureBoxEndTile;
		private System.Windows.Forms.PictureBox pictureBoxBlockTile;
		public System.Windows.Forms.PictureBox pictureBoxCurrentTile;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadLevelToolStripMenuItem;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.PictureBox pictureBoxEmpty;
	}
}