using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingWallScript : MonoBehaviour {
    private Vector2 maxHeight;
    private Vector2 startHeight;
    private Vector2 updateHeight;
    private bool shrink;
    private float magicNumber;

	void Start ()
    {
        maxHeight.y = 4;
        startHeight = transform.localScale;
        magicNumber = 0.07f;
    }
	
	
	void Update ()
    {
        if(Time.timeScale > 0)
        {
            updateHeight = transform.localScale;

            if (updateHeight.y < maxHeight.y && shrink == false)
            {
                updateHeight.y += (magicNumber);
                gameObject.transform.localScale = updateHeight;

                transform.Translate((Vector2.up * (magicNumber / 2f)));
            }
            else
            {
                shrink = true;
            }

            if (shrink == true && updateHeight != startHeight)
            {
                updateHeight.y -= (magicNumber);
                gameObject.transform.localScale = updateHeight;
                transform.Translate((Vector2.down * (magicNumber / 2f)));
            }
            else
            {
                shrink = false;
            }
        }
     
    }
}
