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
    ParticleSystem spark;
    
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        bullet = this.gameObject.transform.position;
        spark = GetComponent<ParticleSystem>();
        spark.enableEmission = false;
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
        else if (velocityY == 0)
        {
            rigidbody.velocity = new Vector2(velocityX, velocityY);
            Destroy(gameObject, 3f);
        }
        else if (velocityY == 1)
        {
            rigidbody.velocity = new Vector2(velocityX, velocityY);
            Destroy(gameObject, 3f);
        }
        else if (velocityY == 2)
        {
            rigidbody.velocity = new Vector2(velocityX, velocityY);
            Destroy(gameObject, 3f);
        }
        else if (velocityY == -1)
        {
            rigidbody.velocity = new Vector2(velocityX, velocityY);
            Destroy(gameObject, 3f);
        }
        else if (velocityY == -2)
        {
            rigidbody.velocity = new Vector2(velocityX, velocityY);
            Destroy(gameObject, 3f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        spark.enableEmission = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.transform.localScale = new Vector3(0.00001f, 0.00001f, 0.00001f);
        Destroy(gameObject, 0.25f);
    }
}
