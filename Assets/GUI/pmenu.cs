using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pmenu : MonoBehaviour {

    public static bool paused = false;
    public GameObject menu;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                resume();
            else
            {
                pause();
            }
        }
	}

    void resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

    }
}

