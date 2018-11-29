using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour {

    public static int damage;
    public int score;

    private Quaternion fixedRotate;
    private GameObject player;
    private Rigidbody2D playerRigid;
    private Vector3 touchedPosition;
    private GameObject body;
    private bool immune;
    private float immuneTimer;
    public bool detectImmunity;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        body = GameObject.FindGameObjectWithTag("Body");
        score = 0;
        fixedRotate = body.transform.rotation;
        damage = 0;
        immuneTimer = 0;
    }

   
    public void Update()
    {
        Movement();
        DamageProtection();
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchedPosition = Input.mousePosition;
            PointToTouch();
            GameObject.FindGameObjectWithTag("Touch").GetComponent<TouchDetectionScript>().newPos = Camera.main.ScreenToWorldPoint(touchedPosition);
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

    void DamageProtection()
    {
        if(detectImmunity == true)
        {
            immuneTimer += Time.deltaTime;

            if (immuneTimer <= 1f)
            {
                immune = true;
            }
            else
            {
                immune = false;
                detectImmunity = false;
            }
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(detectImmunity == false)
        {
            immuneTimer = 0;
            detectImmunity = true;
        }

        if(immune == false)
        {
            damage++;
        }
    }


}
