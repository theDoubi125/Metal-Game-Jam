using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SudokuCell : MonoBehaviour {
    int value;
    bool valueFixed;
    Text text;

	void Start ()
    {
        text = GetComponentInChildren<Text>();
	}
	
	void Update ()
    {
	    
	}

    public void Incr()
    {
        value++;
        if (value > 9)
            value = -1;
        text.text = "" + value;
        if (value == -1)
            text.text = "-";
    }
}
