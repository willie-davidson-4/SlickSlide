using UnityEngine;
using System.Collections;

public static class GlobalVariables
{
	private static int intLevelToLoad;
	public static int LevelToLoad
	{
		get { return intLevelToLoad; }
		set { intLevelToLoad = value; }
	}

	private static int intWorldToLoad;
	public static int WorldToLoad
	{
		get { return intWorldToLoad; }
		set { intWorldToLoad = value; }
	}

/*
	// Use this for initialization
	void Start () 
 * {
	
	}
	
	// Update is called once per frame
	void Update () 
 * {
	
	}
 * */
}
