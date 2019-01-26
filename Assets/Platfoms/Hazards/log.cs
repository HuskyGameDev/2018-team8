using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour {
    Rigidbody2D rb;
    public int rollSpeed = -3;
    bool hit;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.name.Equals("CharacterPrototype (1)")) {
            this.rb.isKinematic = false;
            hit = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (hit)
        {
            rb.velocity = new Vector2(rollSpeed, rb.velocity.y);
        }
	}
}
