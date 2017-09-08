using UnityEngine;
using System.Collections;

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

	private static string strTestLevel1 =
		"nbbbbbe" + ":" +
		"nbbbbbn" + ":" +
		"nbbbbbn" + ":" +
		"nbbbbbn" + ":" +
		"sbbbbbn";

	public static char[,] TestLevel1
	{
		get
		{
			string[] LevelRows = strTestLevel1.Split(':');

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
	}
}
