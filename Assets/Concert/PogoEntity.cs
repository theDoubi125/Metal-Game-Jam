using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PogoEntity : MonoBehaviour
{
    public float strengthRatio = 1;

    private List<Collider2D> colliding = new List<Collider2D>();

    private Rigidbody2D body;
    private CircleCollider2D circleCollider;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
	}
	
	void Update ()
    {
	    foreach(var other in colliding)
        {
            Vector2 forceDir = (Vector2)(transform.position - other.transform.position);
            body.AddForce(forceDir.normalized * strengthRatio / forceDir.magnitude);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        colliding.Add(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        colliding.Remove(other);
    }
}
