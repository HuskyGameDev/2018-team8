using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour {

    bool dash;
    public int dashSpeed = 10;
    public int dashCount = 0;
    public float MoveXAxis;
    public int dashDir = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveXAxis = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Dash"))
        {
            dash = true;
        }
        if (MoveXAxis < 0)
        {
            dashDir = -1;
        }
        
        if(MoveXAxis > 0)
        {
            dashDir = 1;
        }

    }

    private void FixedUpdate()
    {
        if (dash)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dashSpeed * dashDir, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            dashCount++;
            if(dashCount == 10)
            {
                dashCount = 0;
                MoveXAxis = 0;
                dash = false;
            }
        }
    }
}
