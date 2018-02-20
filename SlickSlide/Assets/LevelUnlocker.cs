using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelUnlocker : MonoBehaviour 
{
	int intCurrentWorld;
	int intCurrentLevel;

	// Use this for initialization
	void Start () 
	{
		SaveInfo.CheckLevelProgress(out intCurrentWorld, out intCurrentLevel);

		if (intCurrentLevel == Levels.NumLevels(intCurrentWorld))
		{
			//Unlock new world!
			intCurrentWorld++;
			intCurrentLevel = 0;
		}

		List<TestLevelSelector> LevelSelectors = new List<TestLevelSelector>(FindObjectsOfType<TestLevelSelector>());

		foreach (TestLevelSelector objLevelSelector in LevelSelectors)
		{
			if (objLevelSelector.intWorldToSelect > intCurrentWorld || (objLevelSelector.intWorldToSelect == intCurrentWorld && objLevelSelector.intLevelToSelect > intCurrentLevel + 1))
			{
				objLevelSelector.gameObject.GetComponent<Image>().color = Color.gray;
				objLevelSelector.gameObject.GetComponent<Button>().enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
