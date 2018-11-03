using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{

    // Use this for initialization
    public int damage = 1;
    // public int speed_increase = 25;
    //private int std_speed = 0;
    void Start()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine("damager");
        }

    }

    void damager()
    {
        //std_speed = Player_Movement.instace.playerMovementSpeed;
        PlayerDeath.instace.HP -= damage;
    }
}