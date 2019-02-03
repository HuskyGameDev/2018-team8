using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEnemy : MonoBehaviour
{
    GameObject player;
    Vector2 playerPos;
    Vector2 enemyPos;
    public int moveSpeed = 3;
    public bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.Find("CharacterPrototype (1)");
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
    }
    // Update is called once per frame
    void Update()
    {
        
        if (triggered)
        {
            if (System.Math.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) < moveSpeed)
            {
            playerPos = player.transform.position;
            enemyPos = gameObject.transform.position;
            if (playerPos.x < enemyPos.x)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(-.3f, 0);
            }
            if( playerPos.x > enemyPos.x)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(.3f, 0);
            }
            }
            
        }

    }
}
