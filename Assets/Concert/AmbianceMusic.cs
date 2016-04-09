using UnityEngine;
using System.Collections;

public class AmbianceMusic : MonoBehaviour {

    private AudioSource audioSource;
    private AudioLowPassFilter lowFilter;

    public bool isFilter = false;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        lowFilter = GetComponent<AudioLowPassFilter>();

        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
        
        if(isFilter)
        {
            if (lowFilter.cutoffFrequency > 2000)
                lowFilter.cutoffFrequency -= 100;
            else if (lowFilter.cutoffFrequency > 200)
                lowFilter.cutoffFrequency -= 10;
            else
                lowFilter.cutoffFrequency = 200;
        }
        else
        {
            if (lowFilter.cutoffFrequency < 2000)
                lowFilter.cutoffFrequency += 10;
            else if (lowFilter.cutoffFrequency < 22000)
                lowFilter.cutoffFrequency += 100;
            else
                lowFilter.cutoffFrequency = 22000;
        }

    }
}
