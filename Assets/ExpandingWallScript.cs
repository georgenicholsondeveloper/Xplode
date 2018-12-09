using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingWallScript : MonoBehaviour {
    private Vector2 maxHeight;
    private Vector2 startHeight;
    private Vector2 updateHeight;


    private Vector2 hold;
    private bool shrink;

	void Start ()
    {
        maxHeight.y = 4;
        startHeight = transform.localScale;

       
    }
	
	
	void Update ()
    {

        updateHeight = transform.localScale;

        if (updateHeight.y < maxHeight.y && shrink == false)
        {
            updateHeight.y += 0.070f;
            gameObject.transform.localScale = updateHeight;
            

        }
        else
        {
            shrink = true;
        }

        if (shrink == true && updateHeight != startHeight)
        {
            updateHeight.y -= 0.070f;
            gameObject.transform.localScale = updateHeight;

        }
        else
        {
            shrink = false;
        }
    }
}
