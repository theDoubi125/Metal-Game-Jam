using UnityEngine;
using System.Collections;

public class TelephoneBehaviour : MonoBehaviour {

	private GameObject telephone;

	bool telephoneMoving;
	bool telephoneVisible;

	float visiblePhonePos = -3.5f;
	float hiddenPhonePos = -6.5f;

	// Use this for initialization
	void Start () {

		telephone = GameObject.Find ("Telephone");

		telephoneMoving = false;
		telephoneVisible = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (telephoneMoving) {
			MovePhone();
		}
		if (Input.GetKeyUp (KeyCode.T)) {
			InitMovePhone();
		}
	
	}

	private void MovePhone()
	{
		if (telephoneVisible) 
		{
			if (telephone.transform.position.y < visiblePhonePos) 
			{
				telephone.transform.Translate(new Vector3(0,Time.deltaTime*3,0));
			}

			if (telephone.transform.position.y >= visiblePhonePos)
			{
				EndMovePhone();
			}

		} 
		else 
		{
			if (telephone.transform.position.y > hiddenPhonePos) 
			{
				telephone.transform.Translate(new Vector3(0,- Time.deltaTime*3,0));
            }

			if (telephone.transform.position.y <= hiddenPhonePos) 
			{
				EndMovePhone();
			}
		}

	}

	private void InitMovePhone()
	{
		telephoneMoving = true;
		telephoneVisible = !telephoneVisible;
		MovePhone ();
	}

	private void EndMovePhone()
	{
		telephoneMoving = false;
	}

	public static void SetTelephoneText(string textToWrite)
	{
		GameObject textObject = GameObject.Find ("Telephone/Message");
		if (textObject != null) 
		{
			textObject.GetComponent<TextMesh> ().text = FormatText(textToWrite);
		}
	}

	public static string FormatText(string textToWrite)
	{
		string textToReturn = "";

		for (int i=0; i<7; ++i) //phone has capacity of 7 lines
		{
			string currentSubstring = textToWrite.Substring(0,19);
			int lastWhiteSpace = currentSubstring.LastIndexOf(" ");
			if (lastWhiteSpace == -1)
			{
				textToReturn = textToReturn + currentSubstring;
				break;
			}
			textToReturn = textToReturn + currentSubstring.Substring(0,lastWhiteSpace) + "\n";
			textToWrite = textToWrite.Substring(lastWhiteSpace + 1);
		}

		return textToReturn;
	}

}
