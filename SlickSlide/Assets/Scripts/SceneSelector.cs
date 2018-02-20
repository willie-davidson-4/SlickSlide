using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SceneSelector : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OpenScene(int intSceneIndex)
	{
		SceneManager.LoadScene(intSceneIndex);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

#if UNITY_EDITOR
#if false
	private static string[] ReadNames()
	{
		List<string> temp = new List<string>();
		foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
		{
			if (S.enabled)
			{
				string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
				name = name.Substring(0, name.Length - 6);
				temp.Add(name);
			}
		}

		string enumName = "GameScenes";
		string[] enumEntries = temp.ToArray();
		string filePathAndName = "Assets/Scripts/Enums/" + enumName + ".cs"; //The folder Scripts/Enums/ is expected to exist

		using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
		{
			streamWriter.WriteLine("public enum " + enumName);
			streamWriter.WriteLine("{");
			for (int i = 0; i < enumEntries.Length; i++)
			{
				streamWriter.WriteLine("\t" + enumEntries[i] + ",");
			}
			streamWriter.WriteLine("}");
		}
		AssetDatabase.Refresh();

		return temp.ToArray();
	}

	[MenuItem("CONTEXT/Scene Selector/Update Scene Names")]
	private static void UpdateNames(MenuCommand command)
	{
		//SceneSelector context = (SceneSelector)command.context;
		//context.Scenes = ReadNames();
	}

	private void Reset()
	{
		//Scenes = ReadNames();
		ReadNames();
	}
#endif
#endif
}
