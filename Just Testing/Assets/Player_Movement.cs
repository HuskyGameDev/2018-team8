using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public int playerMovementSpeed = 10; //Change?
    public int playerJumpHeight = 2000; //Change?
    public bool playerDirectionR = true;
    public float MoveXAxis;
    public float MoveYAxis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove();
	}

	//Holds movement controls, animations, character physics
	void PlayerMove() {
        MoveXAxis = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown ("Jump"))
        {
            Jumping();
        }
        if(MoveXAxis > 0.0f && playerDirectionR == false)
        {
            FlipSprite();
        }
        if (MoveXAxis < 0.0f && playerDirectionR == true)
        {
            FlipSprite();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveXAxis * playerMovementSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    //Allows the player to jump
    void Jumping()
    {
        int jumpCounter = 1;
        print("Testing");
        if (jumpCounter != 0)
        {
            MoveYAxis = Input.GetAxis("Vertical");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpHeight);
            

        }

        
    }
    //Flips player sprite when changing directions, left and right.
	void FlipSprite() {
        playerDirectionR = !playerDirectionR;
        Vector2 direction = gameObject.transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
	}

	}