using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingSpike : MonoBehaviour {

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("CharacterPrototype (1)"))
        {
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("CharacterPrototype"))
        {

        } else
        {
            if (collision.collider.CompareTag("Ground"))
            {
                Destroy(gameObject);
            }
        }
    }
}
