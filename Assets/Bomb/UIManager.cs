using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject bombUI, toolIconUI;

	void Start () {
	
	}
	
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            bombUI.SetActive(false);
            toolIconUI.SetActive(false);
        }
    }

    public void OpenBombMenu()
    {
        bombUI.SetActive(true);
        toolIconUI.SetActive(true);
    }
}
