using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerCharacterScript>().score++;
            
            Destroy(gameObject);
            print(collision.GetComponent<PlayerCharacterScript>().score * 100);
        }
    }
}
