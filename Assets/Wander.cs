/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GoToNextPoint();
	}
	
	// Update is called once per frame
	void Update () {
        if (!agent.PathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();
	}

    GoToNextPoint() {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }


}
*/