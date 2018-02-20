using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//TODO: (NOTE) DON'T HAVE TO SCALE THE TILES WHEN HAVE A BIG/SMALL STAGTE, JUST HAVE TO SCALE CAMERA'S "size" PROPERTY

public struct IntVector2
{
	public IntVector2(int intX, int intY)
	{
		x = intX;
		y = intY;
	}

	public int x;
	public int y;
}

public static class Levels
{
	private static string[][] strTestLevels = new string[][]
		{
			new string[] 
			{
				"nttte" + ":" +
				"ntttn" + ":" +
				"itttn",

				"nttttte" + ":" +
				"ntttttn" + ":" +
				"ntttttn" + ":" +
				"ntttttn" + ":" +
				"itttttn",

				"nbbtttttttbnnn" + ":" +
				"nsssbtttttbnnn" + ":" +
				"itttsststsstte" + ":" +
				"nsssbtttttbnnn" + ":" +
				"nbbtttttttbnnn",
			},

			new string[]
			{
				"nttsst" + ":" +
				"nttent" + ":" +
				"nssnns" + ":" +
				"nssnns" + ":" +
				"nttnns" + ":" +
				"ittsst",

				"ntttn" + ":" +
				"ntttn" + ":" +
				"ittte" + ":" +
				"ntttn" + ":" +
				"ntttn"
			}
	};


	public static char[,] LoadLevel(int intWorld, int intLevel)
	{
		intWorld = intWorld - 1;
		intLevel = intLevel - 1;

		string strTestLevel = strTestLevels[intWorld][intLevel];

		string[] LevelRows = strTestLevel.Split(':');

		int xLength = LevelRows[0].Length;
		int yLength = LevelRows.Length;

		char[,] Output = new char[xLength, yLength];

		for (int y = 0; y < yLength; y++)
		{
			for (int x = 0; x < xLength; x++)
			{
				Output[x, y] = LevelRows[y].ToCharArray()[x];
			}
		}

		return Output;
	}

	public static Tile.TileType[,] ConvertCharArrayToTileTypeArray(char[,] Level)
	{
		int intColumns = Level.GetLength(0);
		int intRows = Level.GetLength(1);
		Tile.TileType[,] Output = new Tile.TileType[Level.GetLength(0), Level.GetLength(1)];

		for (int y = 0; y < intRows; y++)
		{
			for (int x = 0; x < intColumns; x++)
			{
				Output[x, y] = ((Tile.TileType)Level[x, y]);
			}
		}

		return Output;
	}

	public static int NumLevels(int intWorld)
	{
		return strTestLevels[intWorld - 1].Length;
	}
}
