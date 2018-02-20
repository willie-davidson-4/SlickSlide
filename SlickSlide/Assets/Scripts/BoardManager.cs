using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

//TODO: Don't have a tutorial! The bullshit ball of light will tell the player to explore. It will comment the first time the player dies or the first time it touches slide tile, etc though.

public class BoardManager : MonoBehaviour
{
	#region Enums
	public enum Direction
	{
		Up,
		Down,
		Left,
		Right,
		None
	};
	#endregion

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
	public GameObject BlockTile;
	public GameObject SlideTile;
	public GameObject StartTile;
	public GameObject EndTile;
	public GameObject EmptyTile;

	private GameObject objTheStartTile;
	private GameObject objTheEndTile;

	int intCurrX = 0;
	int intCurrY = 0;
	float fltNextTileTime = 0.01f;
	float fltCurrTime = 0.0f;
	bool blnSetupBoard = true;
	bool blnPlacing = true;

	int intNumBreakTiles = 0;

	private GameObject objThePlayer;

	Direction enmPreviousDirection = Direction.None;

	#endregion

	// Use this for initialization
	void Start()
	{
		LoadLevel(GlobalVariables.WorldToLoad, GlobalVariables.LevelToLoad);
		fltCurrTime = fltNextTileTime;

		intCurrX = 0;
		intCurrY = goTiles.GetLength(1) - 1;
	}

	// Update is called once per frame
	void Update()
	{
		if (!blnSetupBoard)
		{
			if (objThePlayer == null)
			{
				if (objTheEndTile.GetComponent<Tile>().blnUpdate)
					return;

				objThePlayer = Instantiate(objPlayerPrefab, objTheStartTile.transform.position, Quaternion.identity) as GameObject;
				if (objThePlayer != null && objThePlayer.GetComponent<Player>() != null)
				{
					objThePlayer.GetComponent<Player>().theBoardManager = this;
					objThePlayer.GetComponent<Player>().SetPos(objTheStartTile);
					//gameObject.SetActive(false);
				}
			}

			//TODO: PLAYER MOVEMENT
			IntVector2 v2PlayerMove = objThePlayer.GetComponent<Player>().GetMovement();
			if (TryMove(v2PlayerMove))
			{
				int intDumb = 0;
				//TODO: SOMETHIGN
			}

			if (objTheEndTile == null)
			{
				Debug.Log("No end tile!");
				return;
			}

			return;
		}
		else
		{
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

				if (++intCurrX >= goTiles.GetLength(0))
				{
					intCurrX = 0;
					if (--intCurrY < 0)
					{
						blnSetupBoard = false;
						blnPlacing = !blnPlacing;
					}
				}
			}
		}
	}

	void LoadLevel(int intWorldNumber, int intLevelNumber)
	{
		try
		{
			Tile.TileType[,] LevelTiles = Levels.ConvertCharArrayToTileTypeArray(Levels.LoadLevel(intWorldNumber, intLevelNumber));//Levels.ConvertCharArrayToTileTypeArray(Levels.TestLevel2);
			intColumns = LevelTiles.GetLength(0);
			intRows = LevelTiles.GetLength(1);

			float fltXOffset = (intColumns - 1) / 2.0f;
			float fltYOffset = (intRows - 1) / 2.0f;

			goTiles = new GameObject[intColumns, intRows];



			for (int y = 0; y < intRows; y++)
			{
				for (int x = 0; x < intColumns; x++)
				{
					GameObject newTile = null;

					switch (LevelTiles[x, y])
					{
						case Tile.TileType.EmptyTile:
							newTile = EmptyTile;
							continue;
						case Tile.TileType.StartTile:
							newTile = StartTile;
							break;
						case Tile.TileType.EndTile:
							newTile = EndTile;
							break;
						case Tile.TileType.StepTile:
							newTile = BreakTile;
							intNumBreakTiles++;
							break;
						case Tile.TileType.BlockTile:
							newTile = BlockTile;
							break;
						case Tile.TileType.SlideTile:
							newTile = SlideTile;
							break;
						default:
							newTile = BaseTile;
							break;
					}

					goTiles[x, y] = GameObject.Instantiate(newTile, new Vector3(x - fltXOffset, ((intRows - 1) - y) - fltYOffset, 0.0f), Quaternion.identity) as GameObject;
					goTiles[x, y].SetActive(false);
					goTiles[x, y].GetComponent<Tile>().SetPos(new IntVector2(x, y));
					goTiles[x, y].GetComponent<Tile>().theBoardManager = this;

					if (LevelTiles[x, y] == Tile.TileType.StartTile)
						objTheStartTile = goTiles[x, y];
					else if (LevelTiles[x, y] == Tile.TileType.EndTile)
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
		intCurrX = 0;
		intCurrY = goTiles.GetLength(1) - 1;
		fltCurrTime = fltNextTileTime;
		blnSetupBoard = true;
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
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
		//RemoveBoard();
	}

	public void BoardWon()
	{
		SaveInfo.SaveLevelProgress(GlobalVariables.WorldToLoad, GlobalVariables.LevelToLoad);
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);		
		//RemoveBoard();
	}

	bool TryMove(IntVector2 v2TryMove)
	{
		if (objThePlayer == null)
			return false;

		GameObject goPlayerTile = objThePlayer.GetComponent<Player>().Tile;
		if (goPlayerTile == null)
			return false;

		IntVector2 v2PlayerPos = objThePlayer.GetComponent<Player>().GetPos();
		int intPlayerX = v2PlayerPos.x;
		int intPlayerY = v2PlayerPos.y;

		int intMoveX = v2TryMove.x;
		int intMoveY = v2TryMove.y;

		bool Output = false;

		if (intMoveX != 0 || intMoveY != 0)
		{
			if (intMoveX != 0)
				intMoveY = 0;

			GameObject goNewTile = GetTile(intPlayerX + intMoveX, intPlayerY + intMoveY);
			if (goNewTile != null && goNewTile.GetComponent<Tile>() != null && goNewTile.GetComponent<Tile>().UpdateTile(objThePlayer.GetComponent<Player>()))
			{
				if (goPlayerTile != null)
					goPlayerTile.GetComponent<Tile>().UpdateTile(null);

				intPlayerX += intMoveX;
				intPlayerY += intMoveY;
				goPlayerTile = goNewTile;
				transform.position = goPlayerTile.transform.position;

				objThePlayer.GetComponent<Player>().SetPos(goNewTile);

				if (intMoveX > 0)
					enmPreviousDirection = Direction.Right;
				else if (intMoveX < 0)
					enmPreviousDirection = Direction.Left;
				else if (intMoveY > 0)
					enmPreviousDirection = Direction.Down;
				else if (intMoveY < 0)
					enmPreviousDirection = Direction.Up;

				if(goNewTile.GetComponent<SlideTile>() != null)
					TryMove(v2TryMove);
			}

			Output = true;
		}


		return Output;
	}


}
