using UnityEngine;
using System.Collections;

public class MoshPitEntity : MonoBehaviour
{
    public float targetRadius, pushStrength, pushMinDelay, pushMaxDelay;
    public Vector2 target;
    public float time;
    private Rigidbody2D body;

	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        time -= Time.fixedDeltaTime;
        if(time <= 0)
        {
            Push();
        }
	}

    private void ResetDelay()
    {
        time = pushMinDelay + Random.value * (pushMaxDelay - pushMinDelay);
    }

    private void Push()
    {
        Vector2 pushtarget = target + Random.insideUnitCircle * targetRadius;
        body.AddForce((pushtarget - (Vector2)transform.position).normalized * pushStrength / Time.fixedDeltaTime);
        ResetDelay();
    }
}
