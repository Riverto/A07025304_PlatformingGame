using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Transition : MonoBehaviour {

    //Cuando se toca este collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("triggered");
        //Se busca el objeto del jugador
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        //Y se llama al metodo nextLevel
        player.nextLevel();
    }
}
