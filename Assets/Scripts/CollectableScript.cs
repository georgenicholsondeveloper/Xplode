using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {

    private GameObject manager;

    void Start()
    {
        manager = GameObject.Find("GameManager");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            manager.GetComponent<GameManager>().score = manager.GetComponent<GameManager>().score + 100;
            Destroy(gameObject);
        }

    }
    
}
