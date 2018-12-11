using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour {
    private GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
        offset = transform.position - player.transform.position;


        
          //  orthographicSize = 10;
        
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
    }
}


