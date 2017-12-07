using UnityEngine;
using System.Collections;

public class BlockTile : Tile
{
	#region Methods
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		blnMovable = false;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}

	// Update is called once per frame
	public override bool UpdateTile(Player objThePlayer)
	{
		return base.UpdateTile(objThePlayer);
	}
	#endregion
}