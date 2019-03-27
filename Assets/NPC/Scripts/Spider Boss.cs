using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderBoss : MonoBehaviour {


    public int hitpoints;
    public int damage;
    private float damageWait = 1.5f;

    public Slider healthBar;
    public Transform Bottom, Top;
    
	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (damageWait > 0)
        {
            damageWait -= Time.deltaTime;
        }
        healthBar.value = hitpoints;
    }
    
    
}
