using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class BoardManager : MonoBehaviour
{
	#region Properties
	public GameObject objPlayerPrefab;

	private int intColumns = 0;
	private int intRows = 0;
	private GameObject[,] goTiles;
	public GameObject[,] Tiles
	{
		get
		{
			return goTiles;
		}
	}

	public GameObject BaseTile;
	public GameObject BreakTile;
	public GameObject StartTile;
	public GameObject EndTile;
	public GameObject EmptyTile;

	private GameObject objTheStartTile;
	private GameObject objTheEndTile;

	int intCurrX = 0;
	int intCurrY = 0;
	float fltNextTileTime = 0.01f;
	float fltCurrTime = 0.0f;
	bool blnUpdate = true;
	bool blnPlacing = true;

	int intNumBreakTiles = 0;

	private GameObject objThePlayer;
	#endregion

	// Use this for initialization
	void Start()
	{
		LoadLevel(0);
		fltCurrTime = fltNextTileTime;

		intCurrX = 0;
		intCurrY = goTiles.GetLength(1) - 1;
	}

	// Update is called once per frame
	void Update()
	{
		if (!blnUpdate)
		{
			if (!(objTheEndTile.GetComponent<Tile>()).blnUpdate)
			{
				GameObject objThePlayer = Instantiate(objPlayerPrefab, objTheStartTile.transform.position, Quaternion.identity) as GameObject;
				if (objThePlayer != null && objThePlayer.GetComponent<Player>() != null)
				{
					objThePlayer.GetComponent<Player>().theBoardManager = this;
					objThePlayer.GetComponent<Player>().SetPos(objTheStartTile.GetComponent<Tile>().GetPos());
					gameObject.SetActive(false);
				}
			}

			return;
		}

		fltCurrTime -= Time.deltaTime;

		if (fltCurrTime <= 0.0f)
		{
			if (goTiles[intCurrX, intCurrY] != null)
			{
				if (blnPlacing)
					goTiles[intCurrX, intCurrY].SetActive(true);
				else
					goTiles[intCurrX, intCurrY].GetComponent<Tile>().StartRemoving();
				fltCurrTime = fltNextTileTime;
			}

			if (++intCurrX > goTiles.GetLength(0) - 1)
			{
				intCurrX = 0;
				if (--intCurrY < 0)
				{
					blnUpdate = false;
					blnPlacing = !blnPlacing;
				}
			}
		}
	}

	void LoadLevel(int intLevelNumber)
	{
		try
		{
			char[,] CharLevel = Levels.TestLevel1;
			intColumns = CharLevel.GetLength(0);
			intRows = CharLevel.GetLength(1);

			float fltXOffset = (intColumns - 1) / 2.0f;
			float fltYOffset = (intRows - 1) / 2.0f;

			goTiles = new GameObject[intColumns, intRows];

			for (int y = 0; y < intRows; y++)
			{
				for (int x = 0; x < intColumns; x++)
				{
					GameObject newTile = null;

					switch (CharLevel[x, y])
					{
						case 'n':
							newTile = EmptyTile;
							continue;
						case 's':
							newTile = StartTile;
							break;
						case 'e':
							newTile = EndTile;
							break;
						case 'b':
							newTile = BreakTile;
							intNumBreakTiles++;
							break;
						default:
							newTile = BaseTile;
							break;
					}

					goTiles[x, y] = GameObject.Instantiate(newTile, new Vector3(x - fltXOffset, ((intRows - 1) - y) - fltYOffset, 0.0f), Quaternion.identity) as GameObject;
					goTiles[x, y].SetActive(false);
					goTiles[x, y].GetComponent<Tile>().SetPos(new IntVector2(x, y));
					goTiles[x, y].GetComponent<Tile>().theBoardManager = this;

					if (CharLevel[x, y] == 's')
						objTheStartTile = goTiles[x, y];
					else if (CharLevel[x, y] == 'e')
						objTheEndTile = goTiles[x, y];
				}
			}
		}

		catch (Exception e)
		{
			Debug.Log("Error in LoadLevel: " + e.Message);
		}
	}

	void RemoveBoard()
	{
		Debug.Log("Remove Board");
		intCurrX = 0;
		intCurrY = goTiles.GetLength(1) - 1;
		fltCurrTime = fltNextTileTime;
		blnUpdate = true;
		gameObject.SetActive(true);
	}

	public GameObject GetTile(int x, int y)
	{
		if (x < 0 || x > Tiles.GetLength(0) - 1 || y < 0 || y > Tiles.GetLength(1) - 1)
			return null;

		return Tiles[x, y];
	}

	public void BreakTileActivated(IntVector2 TilePos)
	{
		intNumBreakTiles--;
		if (intNumBreakTiles == 0)
			objTheEndTile.GetComponent<EndTile>().Open();
	}

	public void PlayerDied()
	{
		RemoveBoard();
	}

	public void BoardWon()
	{
		RemoveBoard();
	}
}
