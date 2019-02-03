using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multishot : MonoBehaviour
{

    // Use this for initialization
    public float power_time = 2.0f;
    void Start()
    {

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
        Player_Movement.instace.multishotCount += 5;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(power_time);
        Destroy(gameObject);
    }
}