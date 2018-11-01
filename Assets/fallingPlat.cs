using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlat : MonoBehaviour
{

   // GameObject myGameObject = new GameObject("Test Object");
   // Rigidbody2D gameObjectsRigidBody2D = myGameObject.AddComponent<Rigidbody2D>();

    private Rigidbody2D plat;
    public float fallDelay = 2.0f;

    private void Start()
    {
        plat = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(fallDelay);
        plat.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        
    }
}