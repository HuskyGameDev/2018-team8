using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public bool crouching;
    public bool playerDirectionRight = true;
    bool grounded;
    bool jumping;
    public double crouchMod = .2;
    public float fireRate = 0.05f;
    public float groundedSkin = .05f;
    public float moveXAxis;
    public float moveYAxis;
    float nextFire = 0f;
    public int playerMovementSpeed = 10; //Change?
    public int playerJumpHeight = 10; //Change?
    public LayerMask mask;
    //public GameObject projectileToLeft, projectileToRight;
    Vector2 playerSize;
    Vector2 boxSize;
    Vector2 projectilePosition;

    //exists for powerups
    public static Player_Movement instace;

    private void Awake()
    {
        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x, groundedSkin);
        //projectileToLeft = Resources.Load("ProjectileToLeft);
        //projectileToRight = Resources.Load("ProjectileToRight");
    }
    // Use this for initialization
    void Start () {
        // Nothing

        //exists for powerups
        instace = this;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        if(Input.GetKeyDown(KeyCode.RightShift) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

	//Holds movement controls, animations, character physics
	void PlayerMove() {
        int movespeed = playerMovementSpeed;
        moveXAxis = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && grounded)
        {
            jumping = true;
        }
        if (Input.GetButton("Crouch"))
        {
            crouching = true;
        } else
        {
            crouching = false;
        }
        if (moveXAxis > 0.0f && playerDirectionRight == false)
        {
            FlipSprite();
        }
        if (moveXAxis < 0.0f && playerDirectionRight == true)
        {
            FlipSprite();
        }
        if (crouching)
        {
            movespeed = (int) (movespeed * crouchMod);
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveXAxis * movespeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    //Allows the player to jump
    void Jumping()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpHeight, ForceMode2D.Impulse);       
    }
    //Flips player sprite when changing directions, left and right.
	void FlipSprite() {
        playerDirectionRight = !playerDirectionRight;
        Vector2 direction = gameObject.transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
	}

    void Fire()
    {
        projectilePosition = transform.position;
        if(playerDirectionRight == true)
        {
            projectilePosition += new Vector2(+1f, -0.05f);
            Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity);
        } else
        {
            projectilePosition += new Vector2(-1f, -0.05f);
            Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity);
        }
    }

    private void FixedUpdate() {
        if (jumping)
        {
            Jumping();
            jumping = false;
            grounded = false;
        } else
        {
            Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f;
            grounded = (Physics2D.OverlapBox(boxCenter, boxSize, 0f, mask) != null);
        }
        }

   

  
}