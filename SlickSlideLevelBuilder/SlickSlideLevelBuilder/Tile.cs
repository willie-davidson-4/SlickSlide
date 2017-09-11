using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickSlideLevelBuilder
{
	class Tile
	{
		public Tile(char TileChar)
		{
			chrTileChar = TileChar;
		}

		private string strImagePath;
		private char chrTileChar;

		public void UpdateImageFile(string strImageFilePath)
		{
			strImagePath = strImageFilePath;
		}

		public string GetImageFile()
		{
			return strImagePath;
		}

		public char GetChar()
		{
			return chrTileChar;
		}
	}
}
