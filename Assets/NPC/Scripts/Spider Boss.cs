using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBoss : MonoBehaviour {


    private int speed = 1;
    private int hitpoints = 40;
    private int startDistance = 10;
    private Vector2 projectilePosition;

    public Transform target;
    public Transform Bottom, Top;
    
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, target.position) <= startDistance) {
            Descend();
        }
	}
    /*
    void Encounter() {
        Descend();
        yield return new WaitForSeconds(3);
        Shoot();
        yield return new WaitForSeconds(3);
        Shoot();
        yield return new WaitForSeconds(3);
        Melee();
        yield return new WaitForSeconds(3);
        Melee();
        yield return new WaitForSeconds(3);
        Ascend();
        yield return new WaitForSeconds(3);
        Shoot();
        yield return new WaitForSeconds(3);
        Shoot();
        yield return new WaitForSeconds(3);
        Shoot();
        yield return new WaitForSeconds(3);
        Shoot();

    }
    */

    void Descend() {
        this.transform.position = Vector3.Lerp(this.transform.position, Bottom.position, Time.deltaTime * speed);
        Shoot();
        Shoot();
        Melee();
        Melee();
    }

    void Ascend() {
        this.transform.position = Vector3.Lerp(this.transform.position, Top.position, Time.deltaTime * speed);
    }

    void Shoot() {
        projectilePosition = transform.position;
        if (target.position.x < (projectilePosition.x - 2))
        {
            projectilePosition += new Vector2(-1f, 0f);
        }
        else if (target.position.x > (projectilePosition.x + 2))
        {
            projectilePosition += new Vector2(1f, 0f);
        }
        else if ((target.position.x <= (projectilePosition.x - 2) && target.position.x >= (projectilePosition.x + 2)) && target.position.y >= projectilePosition.y)
        {
            projectilePosition += new Vector2(0f, 1f);
        }
        else if ((target.position.x <= (projectilePosition.x - 2) && target.position.x >= (projectilePosition.x + 2)) && target.position.y <= projectilePosition.y)
        {
            projectilePosition += new Vector2(0f, -1f);
        }
        Instantiate(Resources.Load("ProjectileTurret"), projectilePosition, Quaternion.identity);
    }

    void Melee() {
        if(Vector3.Distance(transform.position, target.position) <= 1) {
            target.GetComponent<PlayerDeath>().HP -= 1;
        }
    }
}
