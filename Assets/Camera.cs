using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    private GameObject player;
    public float xLeftBound;
    public float xRightBound;
    public float yUpBound;
    public float yDownBound;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xLeftBound, xRightBound);
        float y = Mathf.Clamp(player.transform.position.y, yUpBound, yDownBound);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
