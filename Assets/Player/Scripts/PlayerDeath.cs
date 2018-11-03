using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public int HP;
    public bool died;

    // Use this for initialization
    void Start()
    {
        died = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Killer"))
        {
            StartCoroutine("Death");
        }
    }

    void Death()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
