using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

//https://forum.unity.com/threads/how-to-save-the-player-progress-in-the-game.441465/

//this script saves and loads all the info we want
public static class SaveInfo
{
	static SaveInfo()
	{
		LoadData();
	}

	//data is what is finally saved
	private static Dictionary<string, int> data;

	private static string strSaveInfoFile = "PlayerInfo.save";

	public static void SaveLevelProgress(int intWorld, int intLevel, bool blnForceSave = false)
	{
		if (blnForceSave)
		{
			data["LatestWorld"] = intWorld;
			data["LatestLevel"] = intLevel;
		}
		else
		{
			int intSavedWorld = -1;
			int intSavedLevel = -1;

			CheckLevelProgress(out intSavedWorld, out intSavedLevel);
			if (intSavedWorld == -1 || intWorld > intSavedWorld)
				data["LatestWorld"] = intWorld;
			if (intSavedLevel == -1 || (intWorld >= intSavedWorld && intLevel > intSavedLevel))
				data["LatestLevel"] = intLevel;
		}

		SaveData();
	}

	public static void CheckLevelProgress(out int intWorld, out int intLevel)
	{
		intWorld = -1;
		intLevel = -1;

		try
		{
			LoadData();

			if (data == null)
				return;

			intWorld = data["LatestWorld"];
			intLevel = data["LatestLevel"];
		}
		finally
		{
			if (intWorld == -1)
			{
				intWorld = 1;
				intLevel = 0;

				data = new Dictionary<string, int>();
				data["LatestWorld"] = intWorld;
				data["LatestLevel"] = intLevel;

				SaveData();
			}

			Debug.Log("World: " + intWorld + " | Level: " + intLevel);
		}
	}

	public static void ResetLevelProgress()
	{
		SaveLevelProgress(-1, -1, true);
	}

	public static void LoadData()
	{
		//this loads the data
		data = SaveInfo.DeserializeData<Dictionary<string, int>>(strSaveInfoFile);
	}

	public static void SaveData()
	{
		//this saves the data
		SaveInfo.SerializeData(data, strSaveInfoFile);
	}
	public static void SerializeData<T>(T data, string path)
	{
		//this is just magic to save data.
		//if you're interested read up on serialization
		FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
		BinaryFormatter formatter = new BinaryFormatter();
		try
		{
			formatter.Serialize(fs, data);
			Debug.Log("Data written to " + path + " @ " + DateTime.Now.ToShortTimeString());
		}
		catch (SerializationException e)
		{
			Debug.LogError(e.Message);
		}
		finally
		{
			fs.Close();
		}
	}

	public static T DeserializeData<T>(string path)
	{
		//this is the magic that deserializes the data so we can load it
		T data = default(T);

		if (File.Exists(path))
		{
			FileStream fs = new FileStream(path, FileMode.Open);
			try
			{
				BinaryFormatter formatter = new BinaryFormatter();
				data = (T)formatter.Deserialize(fs);
				Debug.Log("Data read from " + path);
			}
			catch (SerializationException e)
			{
				Debug.LogError(e.Message);
			}
			finally
			{
				fs.Close();
			}
		}
		return data;
	}
}