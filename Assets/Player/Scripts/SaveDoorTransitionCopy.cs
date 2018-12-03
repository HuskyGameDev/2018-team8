using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDoorTransitionCopy : MonoBehaviour
{
    [SerializeField] private string level;  //Set what level the door will take you//
    [SerializeField] private string thing;  //Set what triggers this to occur, usually our player//

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.name.Equals(thing) && Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadScene(level);
        }
    }
}