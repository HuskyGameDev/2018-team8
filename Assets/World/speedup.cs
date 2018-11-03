using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedup : MonoBehaviour {

    // Use this for initialization
    public float power_time = 2.0f;
    public int speed_increase = 25;
    private int std_speed = 0;
    void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
           
            StartCoroutine(powerup());
           
        }

    }

     IEnumerator powerup()
     {
        std_speed = Player_Movement.instace.playerMovementSpeed;
        Player_Movement.instace.playerMovementSpeed = speed_increase;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        // GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(power_time);
          //  Destroy(gameObject);
           Player_Movement.instace.playerMovementSpeed = std_speed;

    }
}
