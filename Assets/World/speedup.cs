using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedup : MonoBehaviour {

    // Use this for initialization
    public int speed_increase = 25;
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
           
            StartCoroutine(powerup());
            //Player_Movement.instace.playerMovementSpeed = 10;
        }
    }

     IEnumerator powerup()
     {
            Player_Movement.instace.playerMovementSpeed = speed_increase;
            Destroy(gameObject);
            yield return new WaitForSeconds(2);
    }
}
