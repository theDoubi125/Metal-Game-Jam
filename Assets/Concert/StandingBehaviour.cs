﻿using UnityEngine;
using System.Collections;

public class StandingBehaviour : MoshPitBehaviour
{
    Vector2 target;
    public float replaceSpeed, areaRadius;
    Rigidbody2D body;

	void Start ()
    {
        target = transform.position;
        body = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
	
	}

    void FixedUpdate()
    {
        if(Vector2.Distance(target, transform.position) > areaRadius)
        {
            Vector2 getCloserDir = target - (Vector2)transform.position;
            body.AddForce(getCloserDir.normalized * replaceSpeed);
        }
        /*time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            Push();
        }*/
    }
}
