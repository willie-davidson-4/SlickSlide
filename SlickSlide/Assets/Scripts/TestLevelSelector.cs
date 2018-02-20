using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestLevelSelector : MonoBehaviour 
{
	//TODO: Level 1 unlocks level 2, unlocks level 3, etc. Save player data or something for that.

	public int intWorldToSelect;
	public int intLevelToSelect;
	//public int LevelToSelect 
	//{
	//	get { return intLevelToSelect; }
	//	set { intLevelToSelect = value; }
	//}

	// Use this for initialization
	void Start () 
	{
		if(gameObject.GetComponent<Button>() != null)
			gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);//delegate { ButtonClicked(); });
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ButtonClicked()
	{
		GlobalVariables.WorldToLoad = intWorldToSelect;
		GlobalVariables.LevelToLoad = intLevelToSelect;
		UnityEngine.SceneManagement.SceneManager.LoadScene(2);
	}
}
