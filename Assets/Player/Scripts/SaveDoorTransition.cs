using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDoorTransition : MonoBehaviour
{
    [SerializeField] private string level;
    [SerializeField] private string thing;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.tag.Equals(thing) && Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadScene(level);
        }
    }
}
