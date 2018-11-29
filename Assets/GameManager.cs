using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int score = 0;
    public float time;
    public Text collectableUpdate;
    public Text finalCollectables;
    public Text finalTime;
    public Text finalScore;

    private float total;
    private GameObject menu;
    
	
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        menu = GameObject.Find("ScoreMenu");
    }
	

	void Update ()
    {
        TextDisplayUpdate();
        ScoreUpdate();
    }

    void ScoreUpdate()
    {
        if(EndZoneScript.hasFinished == false)
        {
            total = score * 5 - time * 10;
            time = Time.time;
            menu.SetActive(false);
        }   
    }

    void TextDisplayUpdate()
    {   
        collectableUpdate.text = "Points: " + score;
        finalCollectables.text = "Collectables: " + score;
        finalTime.text = "Time Taken: " + time;
        finalScore.text = "Final Score: " + total.ToString("F0")+ " points";
    }
}
