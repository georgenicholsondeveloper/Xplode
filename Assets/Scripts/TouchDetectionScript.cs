using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetectionScript : MonoBehaviour {

    public Vector2 newPos;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        transform.position = newPos;
	}
}
