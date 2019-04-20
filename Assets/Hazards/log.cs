using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour {
    Rigidbody2D rb;
    GameObject player;
    Rigidbody2D playerRB;
    public int rollSpeed = 3;
    public bool directionRight;
    bool detected;
    public bool playerCollide;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Character Prototype (1)");
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.name.Equals("CharacterPrototype (1)")) {
            this.rb.isKinematic = false;
            detected = true;
        }
    }

    

    // Update is called once per frame
    void FixedUpdate () {

        if (detected)
        {
            if (directionRight)
            {
                rb.velocity = new Vector2(rollSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-rollSpeed, rb.velocity.y);
            }
        }

	}
}
