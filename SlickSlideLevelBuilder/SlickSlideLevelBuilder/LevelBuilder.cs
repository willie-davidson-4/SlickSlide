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

		public LevelBuilder(int Rows, int Columns, LevelConfig LevelConfig, PictureBox[,] GivenTileGrid)
		{
			InitializeComponent();

			objLevelConfig = LevelConfig;
			intRows = Rows;
			intColumns = Columns;

			intTileWidth = intTileHeight = 65;

			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			TileGrid = GivenTileGrid;
		}

		#region Enums
		enum Direction
		{
			Up = 0,
			Down,
			Left,
			Right,
			None
		};
		#endregion

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

					//p.MouseEnter += pictureBoxCommon_MouseEnter;
					//p.MouseMove += pictureBoxCommon_MouseMove;

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

		private void toolStripMenuItemSaveLevel_Click(object sender, EventArgs e)
		{
			string strLevel = "";
			for (int row = 0; row < intRows; row++)
			{
				for (int column = 0; column < intColumns; column++)
				{
					if (TileGrid[column, row].Tag == null)
						strLevel += 'n';
					else
						strLevel += ((Tile)TileGrid[column, row].Tag).GetChar();
				}

				strLevel += "\r\n";
			}

			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "Level Files (*.lvl)|*.lvl";

				if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					System.IO.File.WriteAllText(sfd.FileName, strLevel);
				}
			}
		}
		#endregion

		public List<List<Tuple<int, int>>> Solutions = null;
		LevelSolutions objLevelSolutions = null;

		private void solveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Solutions = new List<List<Tuple<int, int>>>();
			int intStartColumn = -1;
			int intStartRow = -1;

			int intMoveTiles = 0;

			for (int row = 0; row < intRows; row++)
			{
				for (int column = 0; column < intColumns; column++)
				{
					//TODO: START CHAR
					if (TileGrid[column, row].Tag != null && ((Tile)TileGrid[column, row].Tag).GetChar() == ((Tile)objLevelConfig.pictureBoxStartTile.Tag).GetChar())
					{
						intStartColumn = column;
						intStartRow = row;
					}
					else if (TileGrid[column, row].Tag != null && ((Tile)TileGrid[column, row].Tag).GetChar() == ((Tile)objLevelConfig.pictureBoxStepTile.Tag).GetChar())
						intMoveTiles++;
				}
			}

			intTotalMoveTiles = intMoveTiles;

			if (intStartRow != -1 && intStartColumn != -1)
				RecursiveSolve(intStartColumn, intStartRow, Direction.None, new List<Tuple<int, int>>(), 0);

			if (objLevelSolutions != null)
				objLevelSolutions.Close();

			objLevelSolutions = new LevelSolutions(TileGrid, Solutions);
			objLevelSolutions.Show();
		}

		//TODO: HAVE A COUNTER THAT COUNTS UP FOR EVERY TILE, MAKING SURE THAT, BY THE TIME WE REACH THE END TILE, WE HAVE STEPPED ON EVERY TILE.
		//TODO: HAVE A LevelSolution FORM OBJECT. ALWAYS CLOSE PREVIOUS ONE AND OPEN THE NEW ONE HERE. PASS IT THE TILE GRID AND THE SOLUTIONS LIST. IT WILL HAVE A DROPBOX TO CHOOSE SOLUTION AND WILL DRAW THE SOLUTION WITH A GREEN LINE).

		int intTotalMoveTiles = -1;

		//TODO: HOW TO STORE ALL THE DIFFERENT PATHS
		private void RecursiveSolve(int intCurrColumn, int intCurrRow, Direction enmPrevDir, List<Tuple<int, int>> CurrentSolutionPath, int intMoveTileCount)
		{
			var CurrentPath = new List<Tuple<int, int>>(CurrentSolutionPath);
			CurrentPath.Add(new Tuple<int, int>(intCurrColumn, intCurrRow));

			if (((Tile)TileGrid[intCurrColumn, intCurrRow].Tag).GetChar() == ((Tile)objLevelConfig.pictureBoxSlideTile.Tag).GetChar())
			{
				bool blnBlockTile = false;
				bool blnEndTile = false;
				int intNewColumn = intCurrColumn;
				int intNewRow = intCurrRow;

				int intCurrentMoveTileCount = intMoveTileCount;

				if (CanMoveToTile(CurrentPath, enmPrevDir, ref intNewColumn, ref intNewRow, ref intCurrentMoveTileCount, out blnBlockTile, out blnEndTile))
				{
					if (!blnBlockTile)
					{
						if (blnEndTile && intMoveTileCount == intTotalMoveTiles/*TODO: YOU HAVE TOUCHED EVERY SINGLE MOVETILE*/)
						{
							CurrentPath.Add(new Tuple<int, int>(intNewColumn, intNewRow));
							Solutions.Add(CurrentPath);
							return;
						}

						RecursiveSolve(intNewColumn, intNewRow, enmPrevDir, CurrentPath, intCurrentMoveTileCount);
					}
				}

				if (!blnBlockTile)
					return;
			}

			for (int i = 0; i < 4; i++)
			{
				bool blnEndTile = false;
				int intNewColumn = intCurrColumn;
				int intNewRow = intCurrRow;

				int intCurrentMoveTileCount = intMoveTileCount;

				bool blnBlockTile = false;
				if (CanMoveToTile(CurrentPath, (Direction)i, ref intNewColumn, ref intNewRow, ref intCurrentMoveTileCount, out blnBlockTile, out blnEndTile))
				{
					if (blnEndTile && intMoveTileCount == intTotalMoveTiles /*TODO: YOU HAVE TOUCHED EVERY SINGLE MOVETILE*/)
					{
						CurrentPath.Add(new Tuple<int, int>(intNewColumn, intNewRow));
						Solutions.Add(CurrentPath);
						return;
					}

					RecursiveSolve(intNewColumn, intNewRow, (Direction)i, CurrentPath, intCurrentMoveTileCount);
				}
			}
		}

		private bool CanMoveToTile(List<Tuple<int, int>> CurrentSolution, Direction enmTryDir, ref int intNewColumn, ref int intNewRow, ref int intMoveTileCount, out bool blnBlockTile, out bool blnEndTile)
		{
			blnEndTile = false;
			blnBlockTile = false;

			switch (enmTryDir)
			{
				case Direction.Up:
					{
						intNewRow--;
						break;
					}
				case Direction.Down:
					{
						intNewRow++;
						break;
					}
				case Direction.Left:
					{
						intNewColumn--;
						break;
					}
				case Direction.Right:
					{
						intNewColumn++;
						break;
					}
				default:
					break;
			}

			if (intNewColumn < 0 || intNewColumn >= TileGrid.GetLength(0))
				return false;
			else if (intNewRow < 0 || intNewRow >= TileGrid.GetLength(1))
				return false;

			if (TileGrid[intNewColumn, intNewRow].Tag == null)
				return false;

			char chrNewTile = ((Tile)TileGrid[intNewColumn, intNewRow].Tag).GetChar();

			//TODO: CHECK IF THIS NEW TILE IS VALID. OTHERWISE, CONTINUE.
			if (chrNewTile == ((Tile)objLevelConfig.pictureBoxStepTile.Tag).GetChar())
			{
				if (CurrentSolution.Contains(new Tuple<int, int>(intNewColumn, intNewRow)))
					return false;
				//Solutions.Add(CurrentSolution);

				intMoveTileCount++;
				return true;
			}
			else if (chrNewTile == ((Tile)objLevelConfig.pictureBoxSlideTile.Tag).GetChar())
				return true;
			else if (chrNewTile == ((Tile)objLevelConfig.pictureBoxEndTile.Tag).GetChar())
			{
				blnEndTile = true;
				return true;
			}
			else if (chrNewTile == ((Tile)objLevelConfig.pictureBoxBlockTile.Tag).GetChar())
				blnBlockTile = true;

			return false;
		}
	}
}
