using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class TelephoneBehaviour : MonoBehaviour {

	static string savedTextMessage = "";

	private GameObject telephone;
	private GameObject telephoneText;

	bool telephoneMoving;
	bool telephoneVisible;

	float visiblePhonePos = 125f;
	float hiddenPhonePos = -125f;

	// Use this for initialization
	void Start () {

		telephone = GameObject.Find ("PhoneEcran");
		telephoneText = GameObject.Find ("PhoneMessage");

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
				telephone.transform.Translate(new Vector3(0,Time.deltaTime*125,0));
				telephoneText.transform.Translate(new Vector3(0,Time.deltaTime*125,0));
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
				telephone.transform.Translate(new Vector3(0,- Time.deltaTime*125,0));
				telephoneText.transform.Translate(new Vector3(0,- Time.deltaTime*125,0));
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
		SetTelephoneText (textToWrite, true);
	}

	public static void SetTelephoneText(string textToWrite, bool isInConcert)
	{
		savedTextMessage = textToWrite;

		GameObject textObject = GameObject.Find ("Telephone/PhoneMessage");
		if (textObject != null) 
		{
			if (isInConcert)
			{
				textObject.GetComponent<Text> ().text = ObfuscateText(textToWrite);
			}
			else
			{
				textObject.GetComponent<Text> ().text = textToWrite;
			}
		}
	}

	public static void SetMessageVisible(bool visible)
	{
		SetTelephoneText (savedTextMessage, !visible);
	}

	private static string ObfuscateText(string textToWrite)
	{
		StringBuilder textToChange = new StringBuilder (textToWrite);
		for (int i=0; i<textToChange.Length; ++i)
		{
			char c = textToChange[i];
			if (c == '\n' || c == ' ')
			{
				continue;
			}
			if (Random.value*5 > 1)
			{
				textToChange[i] = '*';
			}
		}
		return textToChange.ToString();
	}

	//@deprecated
	private static string FormatText(string textToWrite)
	{
		string textToReturn = "";

		for (int i=0; i<7; ++i) //phone has capacity of 7 lines
		{
			string currentSubstring = textToWrite;
			if (textToWrite.Length >= 19)
			{
				currentSubstring = textToWrite.Substring(0,19);
			}
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
