using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float velocityX = 11;
    public float velocityY = 0;
    Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.velocity = new Vector2(velocityX, velocityY);
        Destroy(gameObject, 3f);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
