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

        

        Vector3 direction = target.position - transform.position;

        float distance = direction.sqrMagnitude, dot = Vector3.Dot(transform.forward, direction.normalized);

        if (distance < 16 && Mathf.Abs(1 - dot) < .45f) {

            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}
