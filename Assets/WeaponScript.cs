using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public float speedOfFire = 0;
    public float weaponDamage = 10;
    public LayerMask thingsWeWantToShoot;

    float fireTime = 0;
    Transform endOfWeapon;

    GameObject player;
    Vector3 playerPos;

    private void Start()
    {
        player = GameObject.Find("CharacterPrototype (1)");
    }

    // Use this for initialization
    void Awake () {
        endOfWeapon = transform.FindChild("EndOfWeapon");
        if (endOfWeapon == null)
        {
            Debug.LogError("endOfWeapon not found in WeaponScript..");
        }
	}

    // Update is called once per frame
    void Update () {
        playerPos = player.transform.position;
        if (speedOfFire == 0)
        {
            if(Input.GetKeyDown(KeyCode.RightShift))
            {
                Shoot();
            }
        } else
        {
            if (Input.GetKey(KeyCode.RightShift) && Time.time > fireTime)
            {
                fireTime = Time.time + 1 / speedOfFire;
                Shoot();
            }
        }
	}

    void Shoot()
    {
        Vector2 endOfWeaponPosition = new Vector2(endOfWeapon.position.x, endOfWeapon.position.y);
        float direction = 0;
        if (endOfWeaponPosition.x > playerPos.x)
        {
            direction = 5;
        }
        if (endOfWeaponPosition.x < playerPos.x)
        {
            direction = -5;
        }
        Vector2 playerPosition = new Vector2(playerPos.x + direction, endOfWeaponPosition.y);
        RaycastHit2D impact = Physics2D.Raycast(endOfWeaponPosition, playerPosition, 5, thingsWeWantToShoot);
        Debug.DrawLine(endOfWeaponPosition, playerPosition);
    }
}
