using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRide : MonoBehaviour
{

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
