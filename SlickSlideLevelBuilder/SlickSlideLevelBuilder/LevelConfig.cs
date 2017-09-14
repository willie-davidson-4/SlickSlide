using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SlickSlideLevelBuilder
{
	public partial class LevelConfig : Form
	{
		//TODO: MUST DO -
		//	1. 'Solve' can only create 1 solution.
		//	2. Need to create loading functionality.

		public LevelConfig()
		{
			InitializeComponent();

			pictureBoxStepTile.Tag = new Tile('t');
			pictureBoxSlideTile.Tag = new Tile('s');
			pictureBoxBlockTile.Tag = new Tile('b');
			pictureBoxStartTile.Tag = new Tile('i');
			pictureBoxEndTile.Tag = new Tile('e');
			pictureBoxEmpty.Tag = new Tile('n');

			foreach (Control pb in groupBoxTiles.Controls)
			{
				if (pb is PictureBox)
				{
					char chrCurrentTileChar = ((Tile)((PictureBox)pb).Tag).GetChar();
					((Tile)pb.Tag).UpdateImageFile(LoadFromConfigFile(chrCurrentTileChar));
					((PictureBox)pb).ImageLocation = LoadFromConfigFile(chrCurrentTileChar);
				}
			}
		}

		private void PictureBoxClickLogic(MouseEventArgs me, PictureBox objClickedPicture)
		{
			if (me.Button == MouseButtons.Left && objClickedPicture != pictureBoxEmpty)
			{
				using (OpenFileDialog dlg = new OpenFileDialog())
				{
					dlg.Title = "Open Image";
					dlg.Filter = "png files (*.png)|*.png";

					if (dlg.ShowDialog() == DialogResult.OK)
					{
						((Tile)objClickedPicture.Tag).UpdateImageFile(dlg.FileName);
						objClickedPicture.ImageLocation = dlg.FileName;

						UpdateConfigFile(((Tile)objClickedPicture.Tag).GetChar(), dlg.FileName);
					}
				}
			}
			else
			{
				//Select this tile!
				pictureBoxCurrentTile.Tag = objClickedPicture.Tag;
				pictureBoxCurrentTile.ImageLocation = ((Tile)pictureBoxCurrentTile.Tag).GetImageFile();
			}
		}

		private void pictureBoxCommon_Click(object sender, EventArgs e)
		{
			PictureBoxClickLogic((MouseEventArgs)e, (PictureBox)sender);
		}

		private void buttonNewLevel_Click(object sender, EventArgs e)
		{
			LevelBuilder objLevelBuilder = new LevelBuilder((int)numericUpDownRows.Value, (int)numericUpDownColumns.Value, this);
			objLevelBuilder.Show();
		}

		private void UpdateConfigFile(char chrTileType, string strImagePath)
		{
			if (File.Exists("TileConfig.txt"))
			{
				string[] ConfigContents = File.ReadAllLines("TileConfig.txt");

				int i = 0;
				foreach (string strConfig in ConfigContents)
				{
					try
					{
						if (strConfig.Split(';')[0] == chrTileType.ToString())
						{
							ConfigContents[i] = chrTileType + ";" + strImagePath;
							File.WriteAllLines("TileConfig.txt", ConfigContents);
							return;
						}
					}
					catch
					{ }
				}
			}

			File.AppendAllText("TileConfig.txt", chrTileType + ";" + strImagePath + "\r\n");
		}

		private string LoadFromConfigFile(char chrTileType)
		{
			if (!File.Exists("TileConfig.txt"))
				return "";

			string[] ConfigContents = File.ReadAllLines("TileConfig.txt");

			foreach (string strConfig in ConfigContents)
			{
				try
				{
					if (strConfig.Split(';')[0] == chrTileType.ToString())
					{
						return strConfig.Split(';')[1];
					}
				}
				catch
				{ }
			}

			return "";
		}

		private void loadLevelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "lvl files (*.lvl)|*.lvl";

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					string[] strLevelContents = System.IO.File.ReadAllText(ofd.FileName).Replace("\n", "").Trim().Split("\r".ToArray());

					PictureBox[,] TileGrid = new PictureBox[strLevelContents[0].Length, strLevelContents.Length];


					for (int y = 0; y < strLevelContents.Length; y++)
					{
						for (int x = 0; x < strLevelContents[y].Trim().Length; x++)
						{
							char chrCurrentChar = strLevelContents[y].ToArray()[x];

							foreach (Control pb in groupBoxTiles.Controls)
							{
								if (pb is PictureBox)
								{
									char chrCurrentTileChar = ((Tile)((PictureBox)pb).Tag).GetChar();
									if (chrCurrentTileChar == chrCurrentChar)
									{
										PictureBox p = new PictureBox();
										p.BackColor = Color.Black;
										p.SizeMode = PictureBoxSizeMode.StretchImage;
										p.BorderStyle = BorderStyle.FixedSingle;
										p.Click += pictureBoxCommon_Click;

										p.Tag = ((Tile)((PictureBox)pb).Tag);
										p.ImageLocation = ((((Tile)((PictureBox)pb).Tag) != null) ? ((Tile)((PictureBox)pb).Tag).GetImageFile() : "");

										TileGrid[x, y] = p;
										break;
									}
								}
							}
						}
					}

					LevelBuilder objLevelBuilder = new LevelBuilder((int)strLevelContents.Length, (int)strLevelContents[0].Trim().Length, this, TileGrid);
					objLevelBuilder.Show();
				}
			}
		}
	}
}
