using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour {
    Vector2 projectilePosition;
    Vector3 playerPos;
    public float offsetX = .5f;
    public float offsetY = .5f;
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
        if(playerPos.x < (projectilePosition.x - offsetX))
        {
           projectilePosition += new Vector2(-offsetX, 0f);
        } else if (playerPos.x > (projectilePosition.x + offsetX))
        {
            projectilePosition += new Vector2(offsetX, 0f);
        } else if (playerPos.y >= projectilePosition.y)
        {
            projectilePosition += new Vector2(0f, offsetY);
        } else if (playerPos.y <= projectilePosition.y)
        {
            projectilePosition += new Vector2(0f, -offsetY);
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
