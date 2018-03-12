using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Collider : MonoBehaviour {
    public BoxCollider2D deathCollider;
	
	// Update is called once per frame
	void Update () {
        //se mueve el collider para que este en la orilla de la camara
        deathCollider.transform.position = new Vector3(0, Camera.main.transform.position.y -9.5f, deathCollider.transform.position.z);
	}

    //Cuando se toca este collider
    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("triggered");
        //Se busca el objeto del jugador
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        //Y se llama el metodo death
        player.death();
    }
}
