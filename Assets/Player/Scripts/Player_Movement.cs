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
    public int directionState = 4; // Begin shooting pointed to right
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
        
        // Projectile Directions
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //Up Only
            directionState = 1;
        }
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //Left Only
            directionState = 2;
        }
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //Down Only
            directionState = 3;
        }
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //Right Only
            directionState = 4;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //Up and Left
            directionState = 5;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //Up and Right
            directionState = 6;
        }
        else if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //Down and Left
            directionState = 7;
        }
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //Down and Right
            directionState = 8;
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //WAS Only
            //Left Only
            directionState = 2;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //WAD Only
            //Up Only
            directionState = 1;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //WSD Only
            //Right Only
            directionState = 4;
        }
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //ASD Only
            //Down Only
            directionState = 3;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            //All Keys Pressed
            //Do Nothing
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            chargeRate += 1;
        }
        else
        {
            if (chargeRate > 100)
            {
                chargeRate = 0;
                FireCharged();
            }

            if (chargeRate > 0 && chargeRate <= 100)
            {
                chargeRate = 0;
                nextFire = Time.time + fireRate;
                Fire();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (multishotCount >= 1)
            {
                multishotCount--;
                nextFire = Time.time + fireRate;
                FireMulti();
            }
        }

        /*if (Input.GetKey(KeyCode.Return))
        {
            charging = true;
            chargeRate += 1;
            if (Input.GetKey(KeyCode.RightShift) && chargeRate >= 100) {
                FireCharged();
                chargeRate = 0;
            }
        } else
        {
            charging = false;
        }
        if (Input.GetKey(KeyCode.RightShift) && !(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && charging != true && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
        if (Input.GetKey(KeyCode.RightShift) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
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
        }*/
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

        if(directionState == 1) //Up
        {
            projectilePosition += new Vector2(0f, 1f);
            Instantiate(Resources.Load("ProjectileToSky"), projectilePosition, Quaternion.identity);
        }
        else if (directionState == 2) //Left
        {
            projectilePosition += new Vector2(-1f, 0f);
            Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity);
        }
        else if (directionState == 3) //Down
        {
            projectilePosition += new Vector2(0f, -1f);
            Instantiate(Resources.Load("ProjectileToGround"), projectilePosition, Quaternion.identity);
        }
        else if (directionState == 4) //Right
        {
            projectilePosition += new Vector2(+1f, 0f);
            Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity);
        }
        else if (directionState == 5) //Up, Left
        {
            projectilePosition += new Vector2(-1f, +1f);
            Instantiate(Resources.Load("ProjectileToLeftSky"), projectilePosition, Quaternion.identity);
        }
        else if (directionState == 6) //Up, Right
        {
            projectilePosition += new Vector2(+1f, +1f);
            Instantiate(Resources.Load("ProjectileToRightSky"), projectilePosition, Quaternion.identity);
        }
        else if (directionState == 7) //Down, Left
        {
            projectilePosition += new Vector2(-1f, -1f);
            Instantiate(Resources.Load("ProjectileToLeftGround"), projectilePosition, Quaternion.identity);
        }
        else if (directionState == 8) //Down, Right
        {
            projectilePosition += new Vector2(+1f, -1f);
            Instantiate(Resources.Load("ProjectileToRightGround"), projectilePosition, Quaternion.identity);
        }


        /*if(playerDirectionRight == true)
        {
            projectilePosition += new Vector2(+1f, bulletHeight);
            Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity);
        } else
        {
            projectilePosition += new Vector2(-1f, bulletHeight);
            Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity);
        }*/
    }
    
    void FireCharged()
    {
        projectilePosition = transform.position;

        if (directionState == 1) //Up
        {
            projectilePosition += new Vector2(0f, 1f);
            GameObject projectile = Instantiate(Resources.Load("ProjectileToSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile.transform.localScale = new Vector3(2, 2, 2);
            projectile.GetComponent<TrailRenderer>().startWidth = 0.3f;
            projectile.GetComponent<TrailRenderer>().endWidth = 0.1f;
        }
        else if (directionState == 2) //Left
        {
            projectilePosition += new Vector2(-1f, 0f);
            GameObject projectile = Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity) as GameObject;
            projectile.transform.localScale = new Vector3(2, 2, 2);
            projectile.GetComponent<TrailRenderer>().startWidth = 0.3f;
            projectile.GetComponent<TrailRenderer>().endWidth = 0.1f;
        }
        else if (directionState == 3) //Down
        {
            projectilePosition += new Vector2(0f, -1f);
            GameObject projectile = Instantiate(Resources.Load("ProjectileToGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile.transform.localScale = new Vector3(2, 2, 2);
            projectile.GetComponent<TrailRenderer>().startWidth = 0.3f;
            projectile.GetComponent<TrailRenderer>().endWidth = 0.1f;
        }
        else if (directionState == 4) //Right
        {
            projectilePosition += new Vector2(+1f, 0f);
            GameObject projectile = Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity) as GameObject;
            projectile.transform.localScale = new Vector3(2, 2, 2);
            projectile.GetComponent<TrailRenderer>().startWidth = 0.3f;
            projectile.GetComponent<TrailRenderer>().endWidth = 0.1f;
        }
        else if (directionState == 5) //Up, Left
        {
            projectilePosition += new Vector2(-1f, +1f);
            GameObject projectile = Instantiate(Resources.Load("ProjectileToLeftSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile.transform.localScale = new Vector3(2, 2, 2);
            projectile.GetComponent<TrailRenderer>().startWidth = 0.3f;
            projectile.GetComponent<TrailRenderer>().endWidth = 0.1f;
        }
        else if (directionState == 6) //Up, Right
        {
            projectilePosition += new Vector2(+1f, +1f);
            GameObject projectile = Instantiate(Resources.Load("ProjectileToRightSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile.transform.localScale = new Vector3(2, 2, 2);
            projectile.GetComponent<TrailRenderer>().startWidth = 0.3f;
            projectile.GetComponent<TrailRenderer>().endWidth = 0.1f;
        }
        else if (directionState == 7) //Down, Left
        {
            projectilePosition += new Vector2(-1f, -1f);
            GameObject projectile = Instantiate(Resources.Load("ProjectileToLeftGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile.transform.localScale = new Vector3(2, 2, 2);
            projectile.GetComponent<TrailRenderer>().startWidth = 0.3f;
            projectile.GetComponent<TrailRenderer>().endWidth = 0.1f;
        }
        else if (directionState == 8) //Down, Right
        {
            projectilePosition += new Vector2(+1f, -1f);
            GameObject projectile = Instantiate(Resources.Load("ProjectileToRightGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile.transform.localScale = new Vector3(2, 2, 2);
            projectile.GetComponent<TrailRenderer>().startWidth = 0.3f;
            projectile.GetComponent<TrailRenderer>().endWidth = 0.1f;
        }
    }

    void FireMulti()
    {
        projectilePosition = transform.position;

        if (directionState == 1) //Up
        {
            projectilePosition += new Vector2(0f, 1f);
            GameObject projectile1 = Instantiate(Resources.Load("ProjectileToSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectilePosition += new Vector2(-0.1f, 0f);
            GameObject projectile2 = Instantiate(Resources.Load("ProjectileToSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile2.GetComponent<ProjectileScript>().velocityX = -0.25f;
            projectilePosition += new Vector2(-0.1f, 0f);
            GameObject projectile3 = Instantiate(Resources.Load("ProjectileToSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile3.GetComponent<ProjectileScript>().velocityX = -0.5f;
            projectilePosition += new Vector2(0.3f, 0f);
            GameObject projectile4 = Instantiate(Resources.Load("ProjectileToSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile4.GetComponent<ProjectileScript>().velocityX = 0.25f;
            projectilePosition += new Vector2(0.1f, 0f);
            GameObject projectile5 = Instantiate(Resources.Load("ProjectileToSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile5.GetComponent<ProjectileScript>().velocityX = 0.5f;
        }
        else if (directionState == 2) //Left
        {
            projectilePosition += new Vector2(-1f, 0f);
            GameObject projectile1 = Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity) as GameObject;
            projectilePosition += new Vector2(0f, -0.1f);
            GameObject projectile2 = Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity) as GameObject;
            projectile2.GetComponent<ProjectileScript>().velocityY = -0.25f;
            projectilePosition += new Vector2(0f, -0.1f);
            GameObject projectile3 = Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity) as GameObject;
            projectile3.GetComponent<ProjectileScript>().velocityY = -0.5f;
            projectilePosition += new Vector2(0f, 0.3f);
            GameObject projectile4 = Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity) as GameObject;
            projectile4.GetComponent<ProjectileScript>().velocityY = 0.25f;
            projectilePosition += new Vector2(0f, 0.1f);
            GameObject projectile5 = Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity) as GameObject;
            projectile5.GetComponent<ProjectileScript>().velocityY = 0.5f;
        }
        else if (directionState == 3) //Down
        {
            projectilePosition += new Vector2(0f, -1f);
            GameObject projectile1 = Instantiate(Resources.Load("ProjectileToGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectilePosition += new Vector2(-0.1f, 0f);
            GameObject projectile2 = Instantiate(Resources.Load("ProjectileToGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile2.GetComponent<ProjectileScript>().velocityX = -0.25f;
            projectilePosition += new Vector2(-0.1f, 0f);
            GameObject projectile3 = Instantiate(Resources.Load("ProjectileToGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile3.GetComponent<ProjectileScript>().velocityX = -0.5f;
            projectilePosition += new Vector2(0.3f, 0f);
            GameObject projectile4 = Instantiate(Resources.Load("ProjectileToGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile4.GetComponent<ProjectileScript>().velocityX = 0.25f;
            projectilePosition += new Vector2(0.1f, 0f);
            GameObject projectile5 = Instantiate(Resources.Load("ProjectileToGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile5.GetComponent<ProjectileScript>().velocityX = 0.5f;
        }
        else if (directionState == 4) //Right
        {
            projectilePosition += new Vector2(1f, 0f);
            GameObject projectile1 = Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity) as GameObject;
            projectilePosition += new Vector2(0f, -0.1f);
            GameObject projectile2 = Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity) as GameObject;
            projectile2.GetComponent<ProjectileScript>().velocityY = -0.25f;
            projectilePosition += new Vector2(0f, -0.1f);
            GameObject projectile3 = Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity) as GameObject;
            projectile3.GetComponent<ProjectileScript>().velocityY = -0.5f;
            projectilePosition += new Vector2(0f, 0.3f);
            GameObject projectile4 = Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity) as GameObject;
            projectile4.GetComponent<ProjectileScript>().velocityY = 0.25f;
            projectilePosition += new Vector2(0f, 0.1f);
            GameObject projectile5 = Instantiate(Resources.Load("ProjectileToRight"), projectilePosition, Quaternion.identity) as GameObject;
            projectile5.GetComponent<ProjectileScript>().velocityY = 0.5f;
        }
        else if (directionState == 5) //Up, Left
        {
            projectilePosition += new Vector2(-1f, 1f);
            GameObject projectile1 = Instantiate(Resources.Load("ProjectileToLeftSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectilePosition += new Vector2(-0.1f, -0.1f);
            GameObject projectile2 = Instantiate(Resources.Load("ProjectileToLeftSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile2.GetComponent<ProjectileScript>().velocityX += -0.25f;
            projectilePosition += new Vector2(-0.1f, -0.1f);
            GameObject projectile3 = Instantiate(Resources.Load("ProjectileToLeftSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile3.GetComponent<ProjectileScript>().velocityX += -0.5f;
            projectilePosition += new Vector2(0.3f, 0.3f);
            GameObject projectile4 = Instantiate(Resources.Load("ProjectileToLeftSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile4.GetComponent<ProjectileScript>().velocityY += 0.25f;
            projectilePosition += new Vector2(0.1f, 0.1f);
            GameObject projectile5 = Instantiate(Resources.Load("ProjectileToLeftSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile5.GetComponent<ProjectileScript>().velocityY += 0.5f;
        }
        else if (directionState == 6) //Up, Right
        {
            projectilePosition += new Vector2(1f, 1f);
            GameObject projectile1 = Instantiate(Resources.Load("ProjectileToRightSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectilePosition += new Vector2(0.1f, -0.1f);
            GameObject projectile2 = Instantiate(Resources.Load("ProjectileToRightSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile2.GetComponent<ProjectileScript>().velocityX += 0.25f;
            projectilePosition += new Vector2(0.1f, -0.1f);
            GameObject projectile3 = Instantiate(Resources.Load("ProjectileToRightSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile3.GetComponent<ProjectileScript>().velocityX += 0.5f;
            projectilePosition += new Vector2(-0.3f, 0.3f);
            GameObject projectile4 = Instantiate(Resources.Load("ProjectileToRightSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile4.GetComponent<ProjectileScript>().velocityY += 0.25f;
            projectilePosition += new Vector2(-0.1f, 0.1f);
            GameObject projectile5 = Instantiate(Resources.Load("ProjectileToRightSky"), projectilePosition, Quaternion.identity) as GameObject;
            projectile5.GetComponent<ProjectileScript>().velocityY += 0.5f;
        }
        else if (directionState == 7) //Down, Left
        {
            projectilePosition += new Vector2(-1f, -1f);
            GameObject projectile1 = Instantiate(Resources.Load("ProjectileToLeftGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectilePosition += new Vector2(0.1f, -0.1f);
            GameObject projectile2 = Instantiate(Resources.Load("ProjectileToLeftGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile2.GetComponent<ProjectileScript>().velocityX += 0.25f;
            projectilePosition += new Vector2(0.1f, -0.1f);
            GameObject projectile3 = Instantiate(Resources.Load("ProjectileToLeftGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile3.GetComponent<ProjectileScript>().velocityX += 0.5f;
            projectilePosition += new Vector2(-0.3f, 0.3f);
            GameObject projectile4 = Instantiate(Resources.Load("ProjectileToLeftGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile4.GetComponent<ProjectileScript>().velocityY += 0.25f;
            projectilePosition += new Vector2(-0.1f, 0.1f);
            GameObject projectile5 = Instantiate(Resources.Load("ProjectileToLeftGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile5.GetComponent<ProjectileScript>().velocityY += 0.5f;
        }
        else if (directionState == 8) //Down, Right
        {
            projectilePosition += new Vector2(1f, -1f);
            GameObject projectile1 = Instantiate(Resources.Load("ProjectileToRightGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectilePosition += new Vector2(-0.1f, -0.1f);
            GameObject projectile2 = Instantiate(Resources.Load("ProjectileToRightGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile2.GetComponent<ProjectileScript>().velocityX += -0.25f;
            projectilePosition += new Vector2(-0.1f, -0.1f);
            GameObject projectile3 = Instantiate(Resources.Load("ProjectileToRightGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile3.GetComponent<ProjectileScript>().velocityX += -0.5f;
            projectilePosition += new Vector2(0.3f, 0.3f);
            GameObject projectile4 = Instantiate(Resources.Load("ProjectileToRightGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile4.GetComponent<ProjectileScript>().velocityY += 0.25f;
            projectilePosition += new Vector2(0.1f, 0.1f);
            GameObject projectile5 = Instantiate(Resources.Load("ProjectileToRightGround"), projectilePosition, Quaternion.identity) as GameObject;
            projectile5.GetComponent<ProjectileScript>().velocityY += 0.5f;
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
 