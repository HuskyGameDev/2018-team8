using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderBoss : MonoBehaviour
{

    public int maxHp = 50;
    public int currentHp = 50;
    public int damage = 1;
    private float damageWait = 1.5f;

    public Slider healthBar;
    public Transform Bottom, Top;

    bool isDead = false;
    bool twoThirds = false;
    bool oneThird = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (damageWait > 0)
        {
            damageWait -= Time.deltaTime;
        }
        healthBar.value = currentHp;

        if (currentHp == 0)
        {
            isDead = true;
        }

        if (currentHp <= 2/3 * maxHp)
        {
            twoThirds = true;
        }
        
        if ( currentHp <= 1/3 * maxHp)
        {
            oneThird = true;
        }
    }
}