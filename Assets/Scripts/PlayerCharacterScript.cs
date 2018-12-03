using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour {

    public static int damage;
    public int score;
    public static bool dontMove;
    public bool detectImmunity;

    private Quaternion fixedRotate;
    private GameObject player;
    private SpriteRenderer playerRend;
    private Rigidbody2D playerRigid;
    private Vector3 touchedPosition;
    private GameObject body;
    private Vector2 firstPoint;
    private Vector2 secondPoint;
    private bool immune;
    private float immuneTimer;
   

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        playerRend = player.GetComponentInChildren<SpriteRenderer>();
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
        ImmunityMaterialChange();
        CalculatePause();
      
    }

    void CalculatePause()
    {
        firstPoint = new Vector3(544, 542);
        secondPoint = new Vector3(600, 590);
        if(Input.mousePosition.x > firstPoint.x && Input.mousePosition.y > firstPoint.y) 
        {
            if(Input.mousePosition.x < secondPoint.x && Input.mousePosition.y < secondPoint.y)
            {
                dontMove = true;
            }
        }
        else
        {
            dontMove = false;
        }
    }

    void Movement()
    {
        if(dontMove == false)
        {
            if (Input.GetMouseButtonDown(0) && Time.timeScale > 0.5)
            {
                touchedPosition = Input.mousePosition;
                PointToTouch();
                GameObject.FindGameObjectWithTag("Touch").GetComponent<TouchDetectionScript>().newPos = Camera.main.ScreenToWorldPoint(touchedPosition);
                playerRigid.velocity = Vector2.zero;
                playerRigid.AddForce(-transform.up * 1000);
            }
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

    void ImmunityMaterialChange()
    {
        if(immune == true)
        {
            playerRend.color = Color.red;
        }
        else
        {
            playerRend.color = Color.white;
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
