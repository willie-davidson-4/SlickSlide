using UnityEngine;
using System.Collections;

public class StartTile : Tile
{
	#region Methods
	// Use this for initialization
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		blnMovable = true;
	}

	public override void FixedUpdate()
	{
		if (!base.blnUpdate)
			return;

		base.FixedUpdate();

		if(!base.blnUpdate)
		{

		}
	}

	// Update is called once per frame
	public override bool UpdateTile(Player objThePlayer)
	{
		return true;
	}
	#endregion
}
