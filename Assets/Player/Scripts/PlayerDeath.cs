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

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -6)
        {
            died = true;
        }
        if (died == true)
        {
            StartCoroutine("Death");
        }
    }
    void Death()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

