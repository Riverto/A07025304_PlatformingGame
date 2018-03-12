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
        //Busca el objeto stats que contiene el score y highscore
        stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //Y lo muestra en pantalla usando labels
        ScoreLabel.text = "Score: " +stats.score;
        HighScoreLabel.text = "HighScore: " + stats.HighScore;
    }
}
