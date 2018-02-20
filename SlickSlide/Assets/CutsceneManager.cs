using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CutsceneManager : MonoBehaviour
{
	public enum ConversationSpeed
	{
		Slow,
		Fast,
		Faster
	}

	#region Conversation Vars
	public int intConversation = -1;
	bool blnAllowConversation = false;

	//Milliseconds between character reveals. (Eventually will want to grab this value from a config. This way, user can choose from like 3 speeds).
	public ConversationSpeed enmConversationSpeed;
	private int intConversationSpeed = -1;

	List<string> ConversationLines = new List<string>();
	int intCurrentLine = -1;

	string strCurrentLine = "";
	int intCurrentChar = -1;

	bool blnWaitForInput = true;
	System.Diagnostics.Stopwatch objTimer;

	bool blnSettingUpLine = true;
	#endregion

	#region UI Vars
	public GameObject goSpeechParent;
	public Image imgContinueIcon;
	public Text txtName;
	public Text txtSpeech;
	#endregion

	private AudioSource VoiceSounds;
	private float fltBasePitch = -1;
	public float fltPitchVariance;

	private bool blnClickBuffer = false;

	// Use this for initialization
	void Start()
	{
		strConversations.Add(
			"Test1:This is a test conversation.\r\n" +
			"Test1:We're gonna talk like this for a while.\r\n" +
			"Test2:That's right!\r\n" +
			"Test1:...\r\n" +
			"Test2:...\r\n" +
			"Test1:Got any coke?\r\n");
		/////////////////////////////////////////////////////////////////

		goSpeechParent.SetActive(false);
		objTimer = new System.Diagnostics.Stopwatch();

		txtName.text = "";
		txtSpeech.text = "";

		VoiceSounds = gameObject.GetComponent<AudioSource>();
		fltBasePitch = VoiceSounds.pitch;

		switch (enmConversationSpeed)
		{
			case ConversationSpeed.Slow:
				intConversationSpeed = 50;
				break;
			case ConversationSpeed.Fast:
				intConversationSpeed = 25;
				break;
			case ConversationSpeed.Faster:
				intConversationSpeed = 5;
				break;
			default:
				break;
		}
	}

	void Update()
	{
		if (!Input.GetMouseButton(0))
			blnClickBuffer = false;

		if (!blnWaitForInput)
		{
			if (!VoiceSounds.isPlaying)
			{
				VoiceSounds.pitch = fltBasePitch + (Random.Range(fltPitchVariance * -1, fltPitchVariance));
				VoiceSounds.Play();
			}
		}
		//else if (VoiceSounds.isPlaying)
		//	VoiceSounds.Stop();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!blnAllowConversation)
		{
			if (GetMouseLeft())
				ActivateConversation();
		}
		else
		{
			if (blnSettingUpLine)
			{
				/////////////////////////////////////////////////////
				//Setup Line
				string[] LineData = ConversationLines[intCurrentLine].Split(':');
				txtName.text = LineData[0].Trim();

				strCurrentLine = LineData[1].Trim();
				objTimer.Start();

				blnSettingUpLine = false;
				//////////////////////////////////////////////////////
			}
			else
			{
				//////////////////////////////////////////////////////
				//Revealing Line
				if (!blnWaitForInput)
				{
					if (objTimer.ElapsedMilliseconds >= intConversationSpeed)
					{
						intCurrentChar++;
						if (intCurrentChar == strCurrentLine.Length)
						{
							objTimer.Reset();
							blnWaitForInput = true;

							imgContinueIcon.gameObject.SetActive(true);

							return;
						}

						txtSpeech.text += strCurrentLine[intCurrentChar];

						objTimer.Reset();
						objTimer.Start();
					}
				}

				if (GetMouseLeft())
				{
					if (!blnWaitForInput)
					{
						objTimer.Reset();
						blnWaitForInput = true;

						imgContinueIcon.gameObject.SetActive(true);

						txtSpeech.text = strCurrentLine;
						return;
					}
					else
					{
						blnWaitForInput = false;

						intCurrentChar = -1;
						txtSpeech.text = "";
						blnSettingUpLine = true;
						intCurrentLine++;

						Debug.Log("'Curr Line | Total Lines': " + intCurrentLine + " | " + ConversationLines.Count);

						if (intCurrentLine == ConversationLines.Count)
						{
							//TODO: END CONVERSATION
#if UNITY_EDITOR
							UnityEditor.EditorApplication.isPlaying = false;
#else
							Application.Quit();
#endif
							blnAllowConversation = false;
						}
					}
				}
				//////////////////////////////////////////////////////
			}
		}
	}

	private void ActivateConversation()
	{
		blnAllowConversation = true;
		goSpeechParent.SetActive(true);

		foreach (string strLine in strConversations[intConversation].Split('\n'))
		{
			if (strLine.Length > 0)
				ConversationLines.Add(strLine.Trim());
		}

		intCurrentLine = 0;

		blnWaitForInput = false;
	}

	//FOR NOW
	List<string> strConversations = new List<string>();

	private bool GetMouseLeft()
	{
		if (blnClickBuffer)
		{
			if (!Input.GetMouseButton(0))
				blnClickBuffer = false;
			return false;
		}
		else
		{
			if (Input.GetMouseButton(0))
			{
				blnClickBuffer = true;
				return true;
			}
			else
				return false;
		}
	}
}
