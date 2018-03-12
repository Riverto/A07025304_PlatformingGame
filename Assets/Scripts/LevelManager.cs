using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        //Debug.Log ("New Level load: " + name);
        //  Load the scene requested
        //	Application.LoadLevel (name);    -- This method was deprecated a long time ago
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    //  We added these functions to our previous LevelManager script.
    public void LoadNextLevel()
    {
        Debug.Log("load next level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //  Cuando el jugador muere
    public void playerDied()
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //y llamamos el metodo LostLife
        stats.LostLife();
        //si el jugador aun tiene vidas
        if (stats.lives > 0)
        {
            //recargamos el nivel
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else //si ya no tiene vidas restantes
        {
            //cargamos la escena de perdida
            LoadLevel("lose");
        }
    }

    //cuando el jugador llega a una puerta
    public void playerReachedDoor()
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //llamamos el metodo reachedDoor
        stats.reachedDoor();
        //y cargamos el siguiente nivel
        LoadNextLevel();
    }

    //cuando el jugador llega a la cima
    public void playerReachedTop()
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //lamamos el metodo reachedTop
        stats.reachedTop();
        //y cargamos la escena de ganar
        LoadLevel("Win");
    }

    //cuando el jugador ya no quiere continuar o quiere salir
    public void returnToMenu()
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //lamamos el metodo restart
        stats.restart();
        //y cargamos la escena Start
        LoadLevel("Start");
    }
}
