using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	#region Properties
	GameObject objTile = null;

	public BoardManager theBoardManager;

	int intX;
	int intY;

	public GameObject Tile
	{
		get { return objTile; }
	}

	#endregion

	// Use this for initialization
	void Start()
	{
	}

	bool blnInputBuffer = false;

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
				intY += intMoveX;
				objTile = goNewTile;
				transform.position = objTile.transform.position;
				SetPos(objTile.GetComponent<Tile>().GetPos());
			}

			Output = true;
		}


		return Output;
	}

	public void SetPos(IntVector2 pos)
	{
		intX = pos.x;
		intY = pos.y;
	}

	public IntVector2 GetPos()
	{
		return new IntVector2(intX, intY);
	}
}
