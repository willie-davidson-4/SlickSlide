using UnityEngine;
using System.Collections;

public class BreakTile : Tile
{
	#region Properties
	private bool blnAlreadySteppedOn = false;
	#endregion

	#region Methods
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		blnMovable = true;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}

	// Update is called once per frame
	public override bool UpdateTile(Player objThePlayer)
	{
		bool Output = true;

		if (objThePlayer != null)
		{
			if (!blnAlreadySteppedOn)
			{
				blnAlreadySteppedOn = true;
				theBoardManager.BreakTileActivated(new IntVector2(base.intX, base.intY));
			}
			else
				theBoardManager.PlayerDied();
		}
		else if (blnAlreadySteppedOn)
			gameObject.GetComponent<SpriteRenderer>().color = Color.red;

		return Output;
	}
	#endregion
}
