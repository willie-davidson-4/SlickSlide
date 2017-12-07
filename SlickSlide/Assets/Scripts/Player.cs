using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{


	#region Properties
	//Direction enmPreviousDirection = Direction.None;
	//bool blnInputBuffer = false;

	GameObject objTile = null;

	public BoardManager theBoardManager;

	int intX;
	int intY;

	public GameObject Tile
	{
		get 
		{
 			if(objTile == null)
				objTile = theBoardManager.GetTile(intX, intY);

			return objTile;
		}
	}

	bool blnInputBuffer = false;
	#endregion

	// Use this for initialization
	void Start()
	{
	}


#if false
	// Update is called once per frame
	void FixedUpdate()
	{
		if (!blnInputBuffer)
		{
			if (TryMove(HorizontalAxis(), VerticalAxis()))
				blnInputBuffer = true;
		}
		else if (!Input.anyKey)
			blnInputBuffer = false;
	}

	public Vector2 GetMovement()
	{
		if (!blnInputBuffer)
		{
			if (TryMove(HorizontalAxis(), VerticalAxis()))
				blnInputBuffer = true;
		}
		else if (!Input.anyKey)
			blnInputBuffer = false;
	}

	int VerticalAxis()
	{
		if (Input.GetKey(KeyCode.S))
			return 1;
		else if (Input.GetKey(KeyCode.W))
			return -1;
		else return 0;
	}
	int HorizontalAxis()
	{
		if (Input.GetKey(KeyCode.D))
			return 1;
		else if (Input.GetKey(KeyCode.A))
			return -1;
		else return 0;
	}

	bool TryMove(int intMoveX, int intMoveY)
	{
		//TODO: MOVE THIS STUFF TO BOARD MANAGER (Especially look at the level builder's move stuff)

		bool Output = false;

		if (intMoveX != 0 || intMoveY != 0)
		{
			if (intMoveX != 0)
				intMoveY = 0;

			GameObject goNewTile = theBoardManager.GetTile(intX + intMoveX, intY + intMoveY);
			if (goNewTile != null && goNewTile.GetComponent<Tile>() != null && goNewTile.GetComponent<Tile>().UpdateTile(this))
			{
				if(objTile != null)
					objTile.GetComponent<Tile>().UpdateTile(null);

				intX += intMoveX;
				intY += intMoveY;
				objTile = goNewTile;
				transform.position = objTile.transform.position;

				//TODO: MOVING THE PLAYER SHOULD BE DONE IN BOARD MANAGER
				SetPos(objTile.GetComponent<Tile>().GetPos());

				if (intMoveX > 0)
					enmPreviousDirection = Direction.Right;
				else if (intMoveX < 0)
					enmPreviousDirection = Direction.Left;
				else if (intMoveY > 0)
					enmPreviousDirection = Direction.Down;
				else if (intMoveY < 0)
					enmPreviousDirection = Direction.Up;
				Debug.Log(enmPreviousDirection.ToString());
			}

			Output = true;
		}


		return Output;
	}
#endif

	public void SetPos(GameObject goTheTile)
	{
		IntVector2 pos = goTheTile.GetComponent<Tile>().GetPos();

		intX = pos.x;
		intY = pos.y;

		objTile = goTheTile;

		transform.position = objTile.transform.position;
	}

	public IntVector2 GetPos()
	{
		return new IntVector2(intX, intY);
	}

	#region Movement
	public IntVector2 GetMovement()
	{
		if (!blnInputBuffer)
		{
			int intXMovement = HorizontalAxis();
			int intYMovement = VerticalAxis();
			if (intXMovement != 0 || intYMovement != 0)
				blnInputBuffer = true;

			return new IntVector2(intXMovement, intYMovement);
		}
		else if (!Input.anyKey)
			blnInputBuffer = false;

		return new IntVector2(0, 0);
	}

	int VerticalAxis()
	{
		if (Input.GetKey(KeyCode.S))
			return 1;
		else if (Input.GetKey(KeyCode.W))
			return -1;
		else return 0;
	}
	int HorizontalAxis()
	{
		if (Input.GetKey(KeyCode.D))
			return 1;
		else if (Input.GetKey(KeyCode.A))
			return -1;
		else return 0;
	}
	#endregion
}
