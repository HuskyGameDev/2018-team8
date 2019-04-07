using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyJump : MonoBehaviour
{
    GameObject player;
    Rigidbody2D body;
    Vector2 playerPos;
    Vector2 enemyPos;
    public bool grounded;
    bool jumping;
    public float jumpHeight = 4;
    public bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.Find("CharacterPrototype (1)");
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
         if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                triggered = false;
            }
        }
    // Update is called once per frame

    void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, (float) jumpHeight);
        jumping = false;
    }

    void Update()
    {
        if (grounded && triggered && !jumping)
        {
            playerPos = player.transform.position;
            enemyPos = body.transform.position;

            if(playerPos.y > enemyPos.y + 1)
            {
                jumping = true;
                Jump();
            }
        }
    }
}
