using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour {

    GameObject player;
    Rigidbody2D playerRigid;
    Vector3 touchedPosition;
    GameObject body;
    private Quaternion fixedRotate;
    int touches;
    public int score;
	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        body = GameObject.FindGameObjectWithTag("Body");
        score = 0;
        fixedRotate = body.transform.rotation;

	}

   
    void Update() {
        Movement();
     
	}

    void Movement()
    {
       // touches = Input.touchCount;
        if (Input.GetMouseButtonDown(0))
        {
            //touchedPosition = Input.GetTouch(0);
            touchedPosition = Input.mousePosition;
            PointToTouch();
            GameObject.FindGameObjectWithTag("Touch").GetComponent<TouchTrialScript>().newPos = Camera.main.ScreenToWorldPoint(touchedPosition);
            touches = 0;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(-transform.up * 800);
         
        }
        body.transform.rotation = fixedRotate;
    }

    void PointToTouch()
    {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touchedPosition);
        Vector2 lookDirection = (touchPosition - (Vector2)transform.position).normalized;

        transform.up = lookDirection;
    }

}
