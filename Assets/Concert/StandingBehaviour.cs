using UnityEngine;
using System.Collections;

public class StandingBehaviour : MoshPitBehaviour {
    Vector2 target;
    public float replaceSpeed;
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
        Vector2 pushDir = (Vector2)Vector3.Cross(((Vector3)target - transform.position), new Vector3(0, 0, 1));
        Vector2 getCloserDir = target - (Vector2)transform.position;
        body.AddForce(pushDir.normalized * replaceSpeed);
        /*time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            Push();
        }*/
    }
}
