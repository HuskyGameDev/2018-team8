using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public int health = 3;
    bool hit;
    int damageTimer = 0;
    public int invulnTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        damageTimer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Damage") || collision.collider.CompareTag("Bullet")) {
            if (!hit)
            {
                health--;
                if(health == 0)
                {
                    death();
                }
                hit = true;
            }
        }

        if (collision.collider.CompareTag("Killer"))
        {
            death();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (hit)
        {
            damageTimer++;
        }

        if (damageTimer == invulnTime)
        {
            hit = false;
            damageTimer = 0;
        }
    }

    void death()
    {
        Destroy(gameObject);
    }
}
