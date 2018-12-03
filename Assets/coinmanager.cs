using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinmanager : MonoBehaviour
{

    public Text score;
    public int points = 0;

    public static coinmanager instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
        score.text = "Score : " + points;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + points;
    }
}