using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public int HP;
    public bool died;

    public static PlayerDeath instace;

    // Use this for initialization
    void Start()
    {
        died = false;
        instace = this;
    }

    void Update()
    {
      if(HP <= 0)
        {
            StartCoroutine("Death");
        }
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
        died = true;
        SceneManager.LoadScene("JordanSampleScene");
    }

}
