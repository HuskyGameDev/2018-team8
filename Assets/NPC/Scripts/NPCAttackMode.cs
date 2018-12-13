using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttackMode : MonoBehaviour {

    public float speed;
    public float minDistance;
    public float minAttackDistance;

    Transform target;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update() {

        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) <= minDistance)
        {
            Wander.attack = true;
            transform.position += transform.forward * speed * Time.deltaTime;

            if(Vector3.Distance(transform.position, target.position) <= minAttackDistance)
            {
                 //insert attack function here
            }
        }
    }
}
