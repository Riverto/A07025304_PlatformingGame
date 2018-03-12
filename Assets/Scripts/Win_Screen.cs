using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Screen : MonoBehaviour {
    public Text ScoreLabel;
    public Text HighScoreLabel;
    public StatCounter stats;
	// Use this for initialization
	void Start () {
        stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        ScoreLabel.text = "Score: " +stats.score;
        HighScoreLabel.text = "HighScore: " + stats.HighScore;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
