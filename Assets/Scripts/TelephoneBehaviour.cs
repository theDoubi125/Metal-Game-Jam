using UnityEngine;
using System.Collections;

public class TelephoneBehaviour : MonoBehaviour {

	private GameObject telephone;
	private GameObject telephoneText;

	bool telephoneMoving;
	bool telephoneVisible;

	float visiblePhonePos = -3.5f;
	float hiddenPhonePos = -6.5f;

	// Use this for initialization
	void Start () {

		telephone = GameObject.Find ("Telephone");
		telephoneText = GameObject.Find ("Telephone/Message");

		telephoneMoving = false;
		telephoneVisible = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.T)) {
			Debug.Log("test");
		}

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
				Debug.Log(telephone.transform.position.y);
				Debug.Log(Time.deltaTime*3);
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

	public void SetTelephoneText(string text)
	{
	}

}
