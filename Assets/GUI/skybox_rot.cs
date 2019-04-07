using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox_rot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
	
	// Update is called once per frame
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 2);
    }
}
