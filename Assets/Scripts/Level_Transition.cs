﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Transition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("triggered");
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        player.nextLevel();
    }
}