using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToolCursor : MonoBehaviour
{
    public Sprite[] toolIcons;
    private Image img;

	void Start ()
    {
        img = GetComponent<Image>();
        img.sprite = toolIcons[0];
	}
	
	void Update ()
    {
        transform.position = (Vector2)Input.mousePosition + new Vector2(img.sprite.rect.width/2, -img.sprite.rect.height/2);
	}

    void SelectTool(Sprite icon)
    {
        img.sprite = icon;
    }
}
