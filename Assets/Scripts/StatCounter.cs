using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCounter : MonoBehaviour {
    public GameObject stats;
    public int lives;
    public int initLives;
    public int points;
    public int startPoints;
    public int score;
    public int HighScore;
    private int clears;
    public Text currentLives;
    public Text currentPoints;
    // Use this for initialization
    void Start () {
        lives = initLives;
        clears = 0;
        score = 0;
        points = 0;
        HighScore = 0;
        stats = GameObject.Find("Stats");
        //  If the instance is null, then we instanciate this GameObject
        //  and set it to not be destroyed when changing scenes
        if (stats == null)
        {
            stats = this.gameObject;
            stats.name = "Stats";
            DontDestroyOnLoad(stats);
        }
        else
        //if the instance is not null, then we destroy this GameObject
        {
            Destroy(this.gameObject);
        }
        Update();
    }
	
	// Update is called once per frame
	void Update () {
        currentLives = GameObject.Find("Lives").GetComponent<Text>();
        currentPoints = GameObject.Find("Points").GetComponent<Text>();
        currentLives.text = "LIVES:" + lives;
        currentPoints.text = "POINTS:" + points;
	}

    public void LostLife()
    {
        lives--;
        points = startPoints;
        Update();
    }

    public void restart()
    {
        score = 0;
        clears = 0;
        lives = initLives;
    }
    public void reachedTop()
    {
        clears++;
        score += points;
        score += 1000 * clears;
        points = 0;
        if (score > HighScore)
        {
            HighScore = score;
        }
    }
    public void reachedDoor()
    {
        startPoints = points;
    }
}
