using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D body;
    public float speed;

    void Start () {
        body = GetComponent<Rigidbody2D>();
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Standard");
        rend.material.SetColor("_Color", Color.red);
    }
	
	void Update () {
	
	}


	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
		float moveVertical = Input.GetAxis ("Vertical") * speed;

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        body.AddForce(movement);
    }
}
