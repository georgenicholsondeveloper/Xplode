using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int score = 0;
    public bool hasFinished = false;
    public float time;
    public Text collectableUpdate;
    public Text finalCollectables;
    public Text finalTime;
    public Text finalScore;

    private float total;
    
	
	void Start () {
       
    }
	

	void Update () {
        time = Time.time;
        DontDestroyOnLoad(gameObject);
        ScoreUpdate();
        FinalScoreUpdate();
    }

    void FinalScoreUpdate()
    {
        if(hasFinished == false)
        {
            total = score * 5 - time * 10;
        }
    
     
        
    }

    void ScoreUpdate()
    {   
        collectableUpdate.text = "Score: " + score;
        finalCollectables.text = "Collectables: " + score;
        finalTime.text = "Time Taken: " + time;
        finalScore.text = "Final Score: " + total.ToString("F0")+ " points";
    }
}
