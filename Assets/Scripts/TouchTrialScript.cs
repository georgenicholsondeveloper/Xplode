using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrialScript : MonoBehaviour {
    public Vector2 newPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = newPos;
	}
}
