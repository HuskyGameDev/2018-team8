using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{

    public int HP;
    public bool died;
    public Text healthUI;

    public static PlayerDeath instance;

    // Use this for initialization
    void Start()
    {
        healthUI.text = "Health : " + HP;
        died = false;
        instance = this;
    }

    void Update()
    {
        healthUI.text = "Health : " + HP;
        if (HP <= 0)
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
