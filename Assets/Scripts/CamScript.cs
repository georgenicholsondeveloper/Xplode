using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {
    GameObject player;
    private Vector3 camPos;
    Camera cam;

    void Start () {
        cam = gameObject.GetComponent<Camera>();
        camPos = cam.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	
	void Update () {
        Cam();
    }

    void Cam()
    {
        camPos.y = player.transform.position.y;
        camPos.x = player.transform.position.x;
        cam.transform.position = camPos;
    }
}
