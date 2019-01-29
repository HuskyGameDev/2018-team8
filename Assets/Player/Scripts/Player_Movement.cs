using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public bool charging = false;
    public bool crouching;
    public bool playerDirectionRight = true;
    public bool grounded;
    bool jumping;
    public double crouchMod = .2;
    public float bulletHeight = -0.05f;
    public float fireRate = 0.05f;
    public float groundedSkin = .05f;
    public float moveXAxis;
    public float moveYAxis;
    float nextFire = 0f;
    public int chargeRate = 0;
    public int multishotCount = 0;
    public int playerMovementSpeed = 10; //Change?
    public int playerJumpHeight = 10; //Change?
    public LayerMask mask = 0;
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
    void Update() {
        PlayerMove();
        if (Input.GetKey(KeyCode.Return))
        {
            charging = true;
            chargeRate += 1;
            if (Input.GetKeyDown(KeyCode.RightShift) && chargeRate >= 100) {
                FireCharged();
                chargeRate = 0;
            }
        } else
        {
            charging = false;
        }
        if (Input.GetKeyDown(KeyCode.RightShift) && !(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && charging != true && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.RightShift) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            if (multishotCount >= 1)
            {
                nextFire = Time.time + fireRate;
                FireMulti();
                multishotCount--;
            } else
            {
                nextFire = Time.time + fireRate;
                Fire();
            }
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
            bulletHeight = -0.20f;
        } else
        {
            crouching = false;
            bulletHeight = -0.00f;
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
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
            projectilePosition += new Vector2(+1f, bulletHeight);
            Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity);
        } else
        {
            projectilePosition += new Vector2(-1f, bulletHeight);
            Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity);
        }
    }

    void FireCharged()
    {
        projectilePosition = transform.position;
        if (playerDirectionRight == true)
        {
            projectilePosition += new Vector2(+1f, bulletHeight);
            Instantiate(Resources.Load("ProjectileToRightCharged"), projectilePosition, Quaternion.identity);
        }
        else
        {
            projectilePosition += new Vector2(-1f, bulletHeight);
            Instantiate(Resources.Load("ProjectileToLeftCharged"), projectilePosition, Quaternion.identity);
        }
    }

    void FireMulti()
    {
        if (playerDirectionRight == true)
        {
            projectilePosition = transform.position;
            projectilePosition += new Vector2(+1f, bulletHeight);
            Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
            projectilePosition += new Vector2(+1f, bulletHeight + 0.1f);
            Instantiate(Resources.Load("ProjectileToRight(Multishot 1)"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
            projectilePosition += new Vector2(+1f, bulletHeight - 0.1f);
            Instantiate(Resources.Load("ProjectileToRight(Multishot -1)"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
            projectilePosition += new Vector2(+1f, bulletHeight + 0.2f);
            Instantiate(Resources.Load("ProjectileToRight(Multishot 2)"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
            projectilePosition += new Vector2(+1f, bulletHeight - 0.2f);
            Instantiate(Resources.Load("ProjectileToRight(Multishot -2)"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
        }
        else
        {
            projectilePosition = transform.position;
            projectilePosition += new Vector2(-1f, bulletHeight);
            Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
            projectilePosition += new Vector2(-1f, bulletHeight + 0.1f);
            Instantiate(Resources.Load("ProjectileToLeft(Multishot 1)"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
            projectilePosition += new Vector2(-1f, bulletHeight - 0.1f);
            Instantiate(Resources.Load("ProjectileToLeft(Multishot -1)"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
            projectilePosition += new Vector2(-1f, bulletHeight + 0.2f);
            Instantiate(Resources.Load("ProjectileToLeft(Multishot 2)"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
            projectilePosition += new Vector2(-1f, bulletHeight - 0.2f);
            Instantiate(Resources.Load("ProjectileToLeft(Multishot -2)"), projectilePosition, Quaternion.identity);
            projectilePosition = transform.position;
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