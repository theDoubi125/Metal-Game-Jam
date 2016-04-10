using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToolCursor : MonoBehaviour
{
    public Sprite[] toolIcons;
    private Image img;

	void Start ()
    {
        img = GetComponentInChildren<Image>();
        img.sprite = toolIcons[0];
	}
	
	void Update ()
    {
        transform.position = (Vector2)Input.mousePosition;
	}

    void SelectTool(Sprite icon)
    {
        img.sprite = icon;
    }
}
