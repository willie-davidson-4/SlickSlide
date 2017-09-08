using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SlickSlideLevelBuilder
{
	public partial class LevelBuilder : Form
	{
		public LevelBuilder(int Rows, int Columns, LevelConfig LevelConfig)
		{
			InitializeComponent();

			objLevelConfig = LevelConfig;
			intRows = Rows;
			intColumns = Columns;

			intTileWidth = intTileHeight = 65;

			this.FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		#region Properties
		LevelConfig objLevelConfig = null;
		int intRows;
		int intColumns;

		int intTileWidth;
		int intTileHeight;

		PictureBox[,] TileGrid = null;
		#endregion

		#region Methods
		private void UpdateTiles()
		{
			clearLevelToolStripMenuItem_Click(null, null);

			PictureBox[,] OldTileGrid = null;
			if (TileGrid != null)
				OldTileGrid = TileGrid;

			TileGrid = new PictureBox[intColumns, intRows];

			int intHeightOffset = menuStrip.Height;

			Size objSize = new Size(intTileWidth, intTileHeight);
			Rectangle objRect = new Rectangle(Point.Empty, objSize);

			//TODO: TRY SWITCHING ROWS AND COLUMNS
			for (int row = 0; row < intRows; row++)
			{
				for (int column = 0; column < intColumns; column++)
				{
					Point currPoint = new Point(intTileWidth * column, intHeightOffset + (intTileHeight * row));

					PictureBox p = new PictureBox();
					p.Size = objSize;
					p.BackColor = Color.Black;
					p.SizeMode = PictureBoxSizeMode.StretchImage;
					p.Location = currPoint;
					p.BorderStyle = BorderStyle.FixedSingle;
					p.Click += pictureBoxCommon_Click;

					p.MouseMove += pictureBoxCommon_MouseMove;
					
					if (OldTileGrid != null && column < OldTileGrid.GetLength(0) && row < OldTileGrid.GetLength(1) && OldTileGrid[column, row] != null)
						SetTile(((Tile)OldTileGrid[column, row].Tag), p);

					this.Controls.Add(p);
					TileGrid[column, row] = p;
				}
			}

			Size WindowSize = new Size();
			WindowSize.Height = intHeightOffset + (intTileHeight * intRows);
			WindowSize.Width = (intTileWidth * intColumns);
			ClientSize = WindowSize;
		}

		private void SetTile(Tile objTile, PictureBox objPictureBox)
		{
			if (objPictureBox == null)
				return;

			objPictureBox.Tag = objTile;
			objPictureBox.ImageLocation = ((objTile != null) ? objTile.GetImageFile() : "");
		}

		private void ShiftLevel(int intShiftHorizontal, int intShiftVertical)
		{
			PictureBox[,] OldTileGrid = null;
			if (TileGrid != null)
				OldTileGrid = TileGrid;

			TileGrid = new PictureBox[intColumns, intRows];

			for (int row = 0; row < intRows; row++)
			{
				for (int column = 0; column < intColumns; column++)
				{
					if (intShiftHorizontal > 0 && column == 0)
					{
						SetTile(null, TileGrid[column, row]);
						continue;
					}
					else if (intShiftHorizontal < 0 && column == (intColumns - 1))
					{
						SetTile(null, TileGrid[column, row]);
						continue;
					}

					if (intShiftVertical > 0 && row == 0)
					{
						SetTile(null, TileGrid[column, row]);
						continue;
					}
					else if (intShiftVertical < 0 && row == (intRows - 1))
					{
						SetTile(null, TileGrid[column, row]);
						continue;
					}

					//TODO: FIGURE OUT WHY IT WANTS -1
					TileGrid[column, row] = OldTileGrid[column + (intShiftHorizontal * -1), row + (intShiftVertical * -1)];
				}
			}

			UpdateTiles();
		}

		public IEnumerable<Control> GetAll(Control control, Type type)
		{
			var controls = control.Controls.Cast<Control>();

			return controls.SelectMany(ctrl => GetAll(ctrl, type))
									  .Concat(controls)
									  .Where(c => c.GetType() == type);
		}
		#endregion

		#region Events
		private void LevelBuilder_Load(object sender, EventArgs e)
		{
			UpdateTiles();
		}

		private void pictureBoxCommon_Click(object sender, EventArgs e)
		{
			PictureBox objPictureBox = (PictureBox)sender;
			SetTile(((Tile)objLevelConfig.pictureBoxCurrentTile.Tag), objPictureBox);
		}

		private void pictureBoxCommon_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				pictureBoxCommon_Click(sender, null);
		}

		private void toolStripMenuItemAddRow_Click(object sender, EventArgs e)
		{
			intRows++;
			UpdateTiles();
		}

		private void toolStripMenuItemAddColumn_Click(object sender, EventArgs e)
		{
			intColumns++;
			UpdateTiles();
		}
		#endregion

		private void toolStripMenuItemRemoveRow_Click(object sender, EventArgs e)
		{
			//TODO: YOU'VE GOT ROWS AND COLUMNS MIXED UP YA DUMMY (APPARENTLY)

			intRows--;
			UpdateTiles();
		}

		private void toolStripMenuItemRemoveColumn_Click(object sender, EventArgs e)
		{
			intColumns--;
			UpdateTiles();
		}

		private void toolStripMenuItemShiftRight_Click(object sender, EventArgs e)
		{
			ShiftLevel(1, 0);
		}

		private void toolStripMenuItemShiftDown_Click(object sender, EventArgs e)
		{
			ShiftLevel(0, 1);
		}

		private void clearLevelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var PictureBoxes = GetAll(this, typeof(PictureBox)).ToArray();
			for (int i = 0; i < PictureBoxes.Count(); i++)
			{
				Control toDelete = PictureBoxes[i];
				PictureBoxes[i] = null;
				Controls.Remove(toDelete);
			}
		}

		private void toolStripMenuItemShiftLeft_Click(object sender, EventArgs e)
		{
			ShiftLevel(-1, 0);
		}

		private void toolStripMenuItemShiftUp_Click(object sender, EventArgs e)
		{
			ShiftLevel(0, -1);
		}
	}
}
