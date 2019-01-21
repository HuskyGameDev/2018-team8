using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{

    public int HP = 3;
    public bool died;
    public Text healthUI;
    public bool hit;
    public int hitTimer = 0;
    public static PlayerDeath instance;
    [SerializeField] private string LevelOfDeath;

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
        if (collision.collider.CompareTag("Damage"))
        {
            if (!hit) { HP--;}
        }
    }

    private void FixedUpdate()
    {
        if (hit)
        {
            hitTimer++;
        }
        if(hitTimer > 60)
        {
            hit = false;
            hitTimer = 0;
        }
    }

    void Death()
    {
        died = true;
        SceneManager.LoadScene(LevelOfDeath);
    }

}
