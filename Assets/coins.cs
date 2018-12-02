using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coins : MonoBehaviour {

    //public Text score;
    //public int points = 0;
    public int value = 1;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine("coin");
        }

    }

    void coin()
    {
        //std_speed = Player_Movement.instace.playerMovementSpeed;
        coinmanager.instance.points += value;
        Destroy(gameObject);
    }
}
