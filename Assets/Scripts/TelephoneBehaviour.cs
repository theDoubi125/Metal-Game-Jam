using UnityEngine;
using System.Collections;
using System.Text;

public class TelephoneBehaviour : MonoBehaviour {

	static string savedTextMessage = "";

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
		
		SetTelephoneText ("Fuck la police de l'information qui fait chier par le trou de caca");

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
		SetTelephoneText (textToWrite, true);
	}

	public static void SetTelephoneText(string textToWrite, bool isInConcert)
	{
		savedTextMessage = textToWrite;

		GameObject textObject = GameObject.Find ("Telephone/Message");
		if (textObject != null) 
		{
			if (isInConcert)
			{
				textObject.GetComponent<TextMesh> ().text = ObfuscateText(FormatText(textToWrite));
			}
			else
			{
				textObject.GetComponent<TextMesh> ().text = FormatText(textToWrite);
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
			if (c == '\n')
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
