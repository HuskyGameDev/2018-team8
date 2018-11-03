using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_spawn : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start () {
        //StartCoroutine("initilize_player");

        player = gameObject.FindWithTag("Player");
        //player = gameObject.Find("CharacterPrototype");
    }

    // Update is called once per frame
    void Update () {
		if (PlayerDeath.instace.died)
        {
            player.transform = this.transform.position;
        }
	}

    //void initilize_player()
    

    


}
