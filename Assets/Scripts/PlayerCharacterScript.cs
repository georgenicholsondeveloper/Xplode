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
        Movement();
	}

    void Movement()
    {

        touches = Input.touchCount;
        if (touches > 0)
        {
            touchedPosition = Input.GetTouch(0);
            PointToTouch();
            GameObject.FindGameObjectWithTag("Touch").GetComponent<TouchTrialScript>().newPos = Camera.main.ScreenToWorldPoint(touchedPosition.position);

            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(-transform.up * 800);



        }
    }

    void PointToTouch()
    {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        Vector2 lookDirection = (touchPosition - (Vector2)transform.position).normalized;

        transform.up = lookDirection;
    }
}
