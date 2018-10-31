/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    //NPC stats subject to change
    int attackDamage = 1;
    int health = 5;
    float npcMoveSpeed = 10f;


	void Start () {
        
    }

    
    void Update() {
        
    }

    // Damage NPC With Bullet
    void OnCollisionEnter2d (Collision2D col){
        if(col.gameObject.tag.equals("Projectile"){
            Destroy(col.gameObject);
            health -= 2;
            if(health <= 0){
                Destroy(gameObject);
            }
        }
    }

}

*/