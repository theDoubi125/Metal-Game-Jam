using UnityEngine;
using System.Collections;

public class SudokuGrid : MonoBehaviour
{
    public Transform sectionPrefab, cellPrefab;
	void Start ()
    {
	    for(int i=0; i<9; i++)
        {
            Transform sectionTransform = Instantiate<Transform>(sectionPrefab);
            sectionTransform.parent = transform;
            for(int j=0; j<9; j++)
            {
                Transform cellTransform = Instantiate<Transform>(cellPrefab);
                cellTransform.parent = sectionTransform;
            }
        }
	}
	
	void Update ()
    {
	
	}
}
