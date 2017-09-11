using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlickSlideLevelBuilder
{
	public partial class LevelSolutions : Form
	{
		public LevelSolutions(PictureBox[,] NewTileGrid, List<List<Tuple<int, int>>> NewSolutions)
		{
			InitializeComponent();
			graphicalOverlay1.Owner = this;

			TileGrid = NewTileGrid;
			intColumns = NewTileGrid.GetLength(0);
			intRows = NewTileGrid.GetLength(1);

			Solutions = NewSolutions;

			objLinePen = new Pen(Color.Green);
		}

		int intTileWidth = 100;
		int intTileHeight = 100;

		int intColumns = -1;
		int intRows = -1;
		PictureBox[,] TileGrid;

		Pen objLinePen;

		List<List<Tuple<int, int>>> Solutions;

		private void LevelSolutions_Load(object sender, EventArgs e)
		{
			PictureBox[,] OldTileGrid = null;
			if (TileGrid != null)
				OldTileGrid = TileGrid;

			TileGrid = new PictureBox[intColumns, intRows];

			Size objSize = new Size(intTileWidth, intTileHeight);
			Rectangle objRect = new Rectangle(Point.Empty, objSize);

			//TODO: TRY SWITCHING ROWS AND COLUMNS
			for (int row = 0; row < intRows; row++)
			{
				for (int column = 0; column < intColumns; column++)
				{
					Point currPoint = new Point(intTileWidth * column, (intTileHeight * row));

					PictureBox p = new PictureBox();
					p.Size = objSize;
					p.BackColor = Color.Black;
					p.SizeMode = PictureBoxSizeMode.StretchImage;
					p.Location = currPoint;
					p.BorderStyle = BorderStyle.FixedSingle;

					//p.MouseEnter += pictureBoxCommon_MouseEnter;
					//p.MouseMove += pictureBoxCommon_MouseMove;

					if (OldTileGrid != null && column < OldTileGrid.GetLength(0) && row < OldTileGrid.GetLength(1) && OldTileGrid[column, row] != null)
						SetTile(((Tile)OldTileGrid[column, row].Tag), p);

					this.Controls.Add(p);
					TileGrid[column, row] = p;
				}
			}

			Size WindowSize = new Size();
			WindowSize.Height = (intTileHeight * intRows) + 50;
			WindowSize.Width = (intTileWidth * intColumns);
			ClientSize = WindowSize;

			objComboBox = new ComboBox();
			objComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			objComboBox.Location = new Point(10, WindowSize.Height - objComboBox.Height - 10);
			this.Controls.Add(objComboBox);

			for (int i = 0; i < Solutions.Count; i++)
			{
				objComboBox.Items.Add("Solution " + i.ToString());
			}

			objComboBox.Items.Add("None");
			objComboBox.SelectedIndex = objComboBox.Items.Count - 1;

			objComboBox.SelectedIndexChanged += objComboBox_SelectedIndexChanged;
		}

		void objComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Refresh();
		}

		ComboBox objComboBox;

		private void SetTile(Tile objTile, PictureBox objPictureBox)
		{
			if (objPictureBox == null)
				return;

			objPictureBox.Tag = objTile;
			objPictureBox.ImageLocation = ((objTile != null) ? objTile.GetImageFile() : "");
		}

		private void LevelSolutions_Paint(object sender, PaintEventArgs e)
		{
			Graphics l = e.Graphics;
			Pen p = new Pen(Color.Green, 10);
			//l.DrawLine(p, 50, 50, 200, 200);
			
			if (objComboBox != null && objComboBox.SelectedIndex >= 0 && objComboBox.SelectedIndex < Solutions.Count)
			{
				using (Pen objPen = new Pen(Color.Green, 3))
				{
					Tuple<int, int> PrevPosition = null;
					foreach (var Position in Solutions[objComboBox.SelectedIndex])
					{
						if (PrevPosition != null)
						{
							Point ptPos1 = new Point((PrevPosition.Item1 * intTileWidth) + (intTileWidth / 2), (PrevPosition.Item2 * intTileHeight) + (intTileHeight / 2));
							Point ptPos2 = new Point((Position.Item1 * intTileWidth) + (intTileWidth / 2), (Position.Item2 * intTileHeight) + (intTileHeight / 2));
							
							l.DrawLine(p, ptPos1, ptPos2);
						}
			
						PrevPosition = Position;
					}
				}
			}
			
			//l.Dispose();
		}
	}
}
