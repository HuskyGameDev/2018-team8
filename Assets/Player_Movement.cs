using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public int playerMovementSpeed = 10; //Change?
    public int playerJumpHeight = 10; //Change?
    public bool playerDirectionR = true;
    public float MoveXAxis;
    public float MoveYAxis;
    public double crouchMod = .2;
    public bool crouching;
    bool jumping;
    bool grounded;
    public float groundedSkin = .05f;
    public float fireRate = 0.05f;
    float nextFire = 0f;
    public LayerMask mask;
    public GameObject projectileToLeft, projectileToRight;

    Vector2 playerSize;
    Vector2 boxSize;
    Vector2 projectilePosition;

    private void Awake()
    {
        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x, groundedSkin);
    }
    // Use this for initialization
    void Start () {
		
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
        MoveXAxis = Input.GetAxis("Horizontal");
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
        if (MoveXAxis > 0.0f && playerDirectionR == false)
        {
            FlipSprite();
        }
        if (MoveXAxis < 0.0f && playerDirectionR == true)
        {
            FlipSprite();
        }
        if (crouching)
        {
            movespeed = (int) (movespeed * crouchMod);
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveXAxis * movespeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    //Allows the player to jump
    void Jumping()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpHeight, ForceMode2D.Impulse);       
    }
    //Flips player sprite when changing directions, left and right.
	void FlipSprite() {
        playerDirectionR = !playerDirectionR;
        Vector2 direction = gameObject.transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
	}

    void Fire()
    {
        projectilePosition = transform.position;
        if(playerDirectionR == true)
        {
            projectilePosition += new Vector2(+1f, -0.05f);
            Instantiate(projectileToRight, projectilePosition, Quaternion.identity);
        } else
        {
            projectilePosition += new Vector2(-1f, -0.05f);
            Instantiate(projectileToLeft, projectilePosition, Quaternion.identity);
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