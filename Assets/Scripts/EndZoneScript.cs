using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneScript : MonoBehaviour {
    public static bool hasFinished;

    private void Start()
    {
        {
            hasFinished = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            hasFinished = true;
        }
    }
}
