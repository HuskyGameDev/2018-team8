using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public float speed;

    Transform waypoint1, waypoint2, destination;

    private void Start() {
        destination = waypoint1;
    }

    private void Update() {

        this.transform.position = Vector3.Lerp(this.transform.position, destination.position, Time.deltaTime * speed);

        var distance = Vector3.Distance(this.transform.position, destination.position);

        if(distance < 1) {
            destination = waypoint2;
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else {
            destination = waypoint1;
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        
        
    }
}
