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
            if(bombUI.active)
            {
                bombUI.SetActive(false);
                toolIconUI.SetActive(false);
                GameState.instance.SetRunning(true);
            }
            else
            {

                bombUI.SetActive(true);
                toolIconUI.SetActive(true);
                GameState.instance.SetRunning(false);
            }
        }
    }

    public void OpenBombMenu()
    {
        GameState.instance.SetRunning(false);
        bombUI.SetActive(true);
        toolIconUI.SetActive(true);
    }
}
