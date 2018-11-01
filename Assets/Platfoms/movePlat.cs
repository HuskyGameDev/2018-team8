using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlat : MonoBehaviour {

    public GameObject platform;
    public float speed;
    public Transform startpoint;
    public Transform[] points;
    public int nextpoint;
    
    // Use this for initialization
	void Start () {
        startpoint = points[nextpoint];


	}
	
	// Update is called once per frame
	void Update () {
        platform.transform.position = Vector3.MoveTowards(
            platform.transform.position, startpoint.position, Time.deltaTime * speed);

        if(platform.transform.position == startpoint.position)
        {
            nextpoint++;
            if(nextpoint == points.Length)
            {
                nextpoint = 0;
            }
        }
        startpoint = points[nextpoint];
	}
}
