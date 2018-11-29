﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour {

    GameObject player;
    Rigidbody2D playerRigid;
    Vector3 touchedPosition;
    GameObject body;

    private Quaternion fixedRotate;

    public int score;
    public int testPublic = 0;
	
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        body = GameObject.FindGameObjectWithTag("Body");
        score = 0;
        fixedRotate = body.transform.rotation;
	}

   
    public void Update() {
        Movement();
        testPublic++;
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
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(-transform.up * 1000);
         
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
