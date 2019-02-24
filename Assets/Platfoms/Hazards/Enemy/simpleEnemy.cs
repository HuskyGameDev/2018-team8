using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEnemy : MonoBehaviour
{
    GameObject player;
    Vector2 playerPos;
    Vector2 enemyPos;
    Rigidbody2D body;
    public int wanderTime = 120; //maxFrames it takes before enemy wanders on its own
    public int frameCount = 0;           //current frame counter
    public int idleTime = 20;       //duration (in frames) of the idle burst movement
    public int moveSpeed = 4;   
    public float acceleration = .33f;
    public bool triggered;
    float direction;
    public bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.Find("CharacterPrototype (1)");
        body = gameObject.GetComponent<Rigidbody2D>();
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
        body.velocity = new Vector2(0, body.velocity.y);
        frameCount = 0;
    }

    private void follow()    //accelerates and moves towards the player
    {
        if (System.Math.Abs(body.velocity.x) < moveSpeed)
        {
            playerPos = player.transform.position;
            enemyPos = body.transform.position;


            if (playerPos.x < enemyPos.x)   //direction to follow the player is determined by x coordinates
            {
                direction = -1;
                facingRight = false;
            }
            else 
            {
                direction = 1;
                facingRight = true;
            }


            body.velocity += new Vector2(direction * acceleration, 0);
        }

        //When acceleration pushes enemies x movement too high, sets it the the max movespeed
        if (System.Math.Abs(body.velocity.x) >= moveSpeed)
        {
            if (body.velocity.x > 0)
            {
                body.velocity = new Vector2(moveSpeed - .01f, body.velocity.y);
            }
            else
            {
                body.velocity = new Vector2(-moveSpeed + .01f, body.velocity.y);
            }
        }
    }

    private void idle()     //wanders idly when player is not currently in tracking range
    {
        if (frameCount == wanderTime) //selects direction for movement at start of idling
        {
            direction = Random.Range(-1, 1) + .001f;
            if (direction < 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }

        if (frameCount < wanderTime + idleTime)
        {
            
            if (Mathf.Abs(body.velocity.x) < moveSpeed/2)
            {
                body.velocity += new Vector2(acceleration * direction, body.velocity.y);
            }
        } else
        {
            body.velocity = new Vector2(0, body.velocity.y);
            frameCount = 0;
        }

    }

    //Flips player sprite when changing directions, left and right.
    void FlipSprite()
    {
        facingRight = !facingRight;
        Vector2 direction = gameObject.transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
    }


    // Update is called once per frame
    void Update()
    {
        if(direction == 1 && !facingRight)
        {
            FlipSprite();
        }

        if(direction == -1 && facingRight)
        {
            FlipSprite();
        }
        //If player is within the trigger zone, follow the player
        if (triggered && frameCount < wanderTime)
        {
            follow();
        }
        else //If player is not in range of the trigger zone, wander about on its own in short bursts
        {
            frameCount++;
            if (wanderTime <= frameCount)
            {
                idle();     
            }
        }
        
    }
}
