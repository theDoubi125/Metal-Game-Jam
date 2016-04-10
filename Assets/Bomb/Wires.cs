﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Wires : MonoBehaviour {

    public Image[] wireStates;
    private int currentState = 0;

	void Start ()
    {

    }

    public void CutFirst()
    {
        CutWire(1);
    }

    public void CutSecond()
    {
        CutWire(2);
    }

    void CutWire(int wire)
    {
        currentState += wire;
        foreach (Image i in wireStates)
        {
            i.gameObject.SetActive(false);
        }
        wireStates[currentState].gameObject.SetActive(true);
    }
}
