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
        //Buscamos los labels que muestran la informacion
        currentLives = GameObject.Find("Lives").GetComponent<Text>();
        currentPoints = GameObject.Find("Points").GetComponent<Text>();
        //Y los actualizamos
        currentLives.text = "LIVES:" + lives;
        currentPoints.text = "POINTS:" + points;
	}

    //Al perder una vida
    public void LostLife()
    {
        //Decrementamos las vidas
        lives--;
        //reiniciamos los puntos a los que tenia al empezar este nivel
        points = startPoints;
        //Y actualizamos los labels
        Update();
    }

    //Al perder todas las vidas o no querer continuar
    public void restart()
    {
        //reiniciamos el score, clears y vidas
        score = 0;
        clears = 0;
        lives = initLives;
    }

    //Cuando el jugador llega a la cima
    public void reachedTop()
    {
        //incrementamos clear
        clears++;
        //sumamos sus puntos al score
        score += points;
        //damos un bonus por numero de clears
        score += 1000 * clears;
        //reiniciamos sus puntos
        points = 0;
        //y si su score es mayor al highscore
        if (score > HighScore)
        {
            //guardamos el nuevo highscore
            HighScore = score;
        }
    }

    //Cuando el jugador llega a una puerta (pasa de un nivel a otro)
    public void reachedDoor()
    {
        //guardamos los puntos con los que llego
        startPoints = points;
    }
}
