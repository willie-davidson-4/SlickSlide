using UnityEngine;
using System.Collections;

public class SlideTile : Tile
{
	#region Constructors
	public SlideTile() : base()
	{
		enmTileType = TileType.SlideTile;
	}
	#endregion

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
		bool Output = true;

		//TODO: If player is not null MOVE HIM TO THE NEXT TILE (unless that's a block tile)

		return Output;
	}
	#endregion
}
