using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttackMode : MonoBehaviour {

    public float speed;

    public Transform target;
    public Transform playerDetection;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update() {

        

        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetection.position, Vector2.left, 3f);

        if (playerInfo.collider == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
