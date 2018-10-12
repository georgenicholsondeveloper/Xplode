using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour {
    GameObject player;
    Rigidbody2D playerRigid;
    Touch touchedPosition;
    int touches;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {

        touches = Input.touchCount;
        if (touches > 0)
        {
            touchedPosition = Input.GetTouch(0);
       //     transform.right = touchedPosition - transform.position;
            GameObject.FindGameObjectWithTag("Touch").GetComponent<TouchTrialScript>().newPos = touchedPosition.position;
       //     if(transform.rotation.z < 90)
         //   {
          //      playerRigid.AddForce(Vector2.right * 10);
           // }
          //  else
            //{
            //    playerRigid.AddForce(Vector2.left * 10);
          //  }
            

        }

        
	}
}
