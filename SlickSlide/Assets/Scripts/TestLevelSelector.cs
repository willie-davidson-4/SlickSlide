using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestLevelSelector : MonoBehaviour 
{
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
		GlobalVariables.LevelToLoad = intLevelToSelect;
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
}
