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

    public void playerDied()
    {
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        stats.LostLife();
        if (stats.lives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            LoadLevel("lose");
        }
    }

    public void playerFinishedLevel()
    {
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        stats.beatLevel();
        LoadLevel("Win");
    }

    public void returnToMenu()
    {
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        stats.restart();
        LoadLevel("Start");
    }
}
