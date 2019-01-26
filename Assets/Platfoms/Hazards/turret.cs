using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {
    Vector2 projectilePosition;
    Vector3 playerPos;
    public bool collide;
    public int fireRate = 0;
    public int maxFire = 60;
    GameObject player;
	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        player = GameObject.Find("CharacterPrototype (1)");
    }

    private void Update()
    {
        playerPos = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.Equals("CharacterPrototype (1)"))
        {
            collide = true;
            Debug.Log("Enter");
        }

    }

   /* private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("CharacterPrototype (1)"))
        {
            collide = true;
            if (fireRate % 15 == 0)
            {
                
                Debug.Log("Staying");
            }
        }
    }
    */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("CharacterPrototype (1)")) {
            collide = false;
            Debug.Log("Exit");
        }
    }
    
    void Fire()
    {
        
        projectilePosition = transform.position;
        if(playerPos.x < (projectilePosition.x - 2))
        {
           projectilePosition += new Vector2(-1f, 0f);
        } else if (playerPos.x > (projectilePosition.x + 2))
        {
            projectilePosition += new Vector2(1f, 0f);
        } else if ((playerPos.x <= (projectilePosition.x - 2) && playerPos.x >= (projectilePosition.x + 2)) && playerPos.y >= projectilePosition.y)
        {
            projectilePosition += new Vector2(0f, 1f);
        } else if ((playerPos.x <= (projectilePosition.x - 2) && playerPos.x >= (projectilePosition.x + 2)) && playerPos.y <= projectilePosition.y)
        {
            projectilePosition += new Vector2(0f, -1f);
        }
    Instantiate(Resources.Load("ProjectileTurret"), projectilePosition, Quaternion.identity);
    }

    private void FixedUpdate()
    {

        if (collide)
        {
            if (fireRate == 0)
            {
                Fire();
            }
        } else
        {
            fireRate = 0;
        }

            fireRate++;
            if (fireRate > maxFire)
            {
                fireRate = 0;
            }

        
        
    }
}
