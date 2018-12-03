using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {
    Vector2 projectilePosition;
    public bool collide;
    public int fireRate = 0;
    public int maxFire = 20;
	// Use this for initialization
	void Start () {
		
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
        projectilePosition += new Vector2(-1f, -0.05f);
        Instantiate(Resources.Load("ProjectileToLeft"), projectilePosition, Quaternion.identity);
    }

    private void FixedUpdate()
    {

        if (collide)
        {
            if (fireRate == 0)
            {
                Fire();
            }
        }

            fireRate++;
            if (fireRate > 20)
            {
                fireRate = 0;
            }

        
        
    }
}
