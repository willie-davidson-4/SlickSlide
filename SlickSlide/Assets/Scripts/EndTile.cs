using UnityEngine;
using System.Collections;

public class EndTile : Tile
{	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		blnMovable = false;
	}

	// Update is called once per frame
	public override void FixedUpdate ()
	{
		base.FixedUpdate();
	}

	public override bool UpdateTile(Player objThePlayer)
	{
		if (blnMovable)
			theBoardManager.BoardWon();
		return blnMovable;
	}

	public void Open()
	{
		blnMovable = true;
	}
}
