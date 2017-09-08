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
	public partial class LevelConfig : Form
	{
		public LevelConfig()
		{
			InitializeComponent();

			pictureBoxStepTile.Tag = new Tile('t');
			pictureBoxSlideTile.Tag = new Tile('s');
			pictureBoxBlockTile.Tag = new Tile('b');
			pictureBoxStartTile.Tag = new Tile('i');
			pictureBoxEndTile.Tag = new Tile('e');
			pictureBoxEmpty.Tag = new Tile('n');
		}

		private void PictureBoxClickLogic(MouseEventArgs me, PictureBox objClickedPicture)
		{
			if(me.Button == MouseButtons.Left && objClickedPicture != pictureBoxEmpty)
			{
				//Look for image file! (And update this)
				using (OpenFileDialog dlg = new OpenFileDialog())
				{
					dlg.Title = "Open Image";
					dlg.Filter = "png files (*.png)|*.png";

					if(dlg.ShowDialog() == DialogResult.OK)
					{
						((Tile)objClickedPicture.Tag).UpdateImageFile(dlg.FileName);
						objClickedPicture.ImageLocation = dlg.FileName;
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
	}
}
