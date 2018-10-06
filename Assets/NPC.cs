using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Monobehaviour {

    //NPC stats subject to change
    int attackDamage = 1;
    int health = 5;
    float npcMoveSpeed = 10f;

    GameObject player;
    CharacterController characterController;
    float moveXAxis;

	void Start () {
        characterController = GetComponent<characterController>();
    }

    
    void Update() {
        transform.poisition += new Vector2(npcMoveSpeed * time.deltaTime, 0, 0);
    }

}