using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float velocityX = 0;
    public float velocityY = 0;
    Rigidbody2D rigidbody;
    Vector2 bullet;
    GameObject player;
    Vector3 playerPos;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        bullet = this.gameObject.transform.position;
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
            rigidbody.velocity = new Vector2(playerPos.x - bullet.x, playerPos.y - bullet.y);
            rigidbody.velocity *= 0.5f;
            Destroy(gameObject, 3f);
        }
        else
        {
            rigidbody.velocity = new Vector2(velocityX, velocityY);
            Destroy(gameObject, 1f);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
