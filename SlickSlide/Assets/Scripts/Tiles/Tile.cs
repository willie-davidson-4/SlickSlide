using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	Quaternion rotDesired;
	Vector3 posDesired;

	private float fltTimeToPlace = 0.5f;
	private float fltDampingDifference = 0.0205f;

	float fltCurrPlaceTime;
	bool blnFinishedPlacing = false;

	Vector3 posStartPos;
	Quaternion rotStartRot;

	public bool blnUpdate = true;

	float fltDampingTesting = 1.0f;

	public int intX;
	public int intY;

	public bool blnMovable = false;

	public bool blnStarting = false;

	public BoardManager theBoardManager = null;

	// Use this for initialization
	public virtual void Start ()
    {
		fltCurrPlaceTime = fltTimeToPlace;

		posDesired = transform.position;
		rotDesired = transform.rotation;

		transform.position = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
		transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0.0f, 0.0f, 7000.0f));

		posStartPos = transform.position;
		rotStartRot = transform.rotation;

		blnStarting = true;
	}

	public virtual void FixedUpdate()
	{
		if (!blnUpdate)
			return;

		if (blnStarting)
		{
			fltCurrPlaceTime -= Time.deltaTime * fltDampingTesting;
			fltDampingTesting -= fltDampingDifference;
			if (fltDampingTesting <= 0.0f)
				fltDampingTesting += fltDampingDifference;

			transform.position = Vector3.Lerp(posDesired, posStartPos, fltCurrPlaceTime / fltTimeToPlace);
			transform.rotation = Quaternion.Lerp(rotDesired, rotStartRot, fltCurrPlaceTime / fltTimeToPlace);

			if (fltCurrPlaceTime <= 0.0f)
			{
				blnUpdate = false;
				blnStarting = true;
			}
		}
		else
		{
			//TODO: GO DOWN, THEN UP!!!

			fltCurrPlaceTime -= Time.deltaTime * fltDampingTesting;
			fltDampingTesting -= fltDampingDifference;
			if (fltDampingTesting <= 0.0f)
				fltDampingTesting += fltDampingDifference;

			transform.position = Vector3.Lerp(posDesired, posStartPos, fltCurrPlaceTime / fltTimeToPlace);
			transform.rotation = Quaternion.Lerp(rotDesired, rotStartRot, fltCurrPlaceTime / fltTimeToPlace);

			if (fltCurrPlaceTime <= 0.0f)
			{
				blnUpdate = false;
				blnStarting = true;
			}
		}
	}

	
	// Update is called once per frame
	public virtual bool UpdateTile (Player objThePlayer)
    {
		Debug.Log("Base update tile!");
		return blnMovable;
	}

	public void SetPos(IntVector2 pos)
	{
		intX = pos.x;
		intY = pos.y;
	}

	public IntVector2 GetPos()
	{
		return new IntVector2(intX, intY);
	}

	public void StartRemoving()
	{
		Debug.Log("StartRemoving");

		fltCurrPlaceTime = fltTimeToPlace;
		
		blnStarting = false;
		blnUpdate = true;

		posDesired = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);
		rotDesired = transform.rotation * Quaternion.Euler(new Vector3(0.0f, 0.0f, 7000.0f));

		posStartPos = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
		rotStartRot = rotDesired = transform.rotation * Quaternion.Euler(new Vector3(0.0f, 0.0f, -10.0f));
	}
}
