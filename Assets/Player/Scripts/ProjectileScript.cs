using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float velocityX = 0;
    public float velocityY = 0;
    Rigidbody2D rigidbody;
    GameObject player;
    Vector3 playerPos;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}

    private void Awake()
    {
        player = GameObject.Find("CharacterPrototype (1)");
    }

    // Update is called once per frame
    void Update () {
        playerPos = player.transform.position;
        if (velocityX == 0 && velocityY == 0)
        {
            rigidbody.velocity = new Vector2(playerPos.x, playerPos.y);
            Destroy(gameObject, 3f);
        }
        else
        {
            rigidbody.velocity = new Vector2(velocityX, velocityY);
            Destroy(gameObject, 3f);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
