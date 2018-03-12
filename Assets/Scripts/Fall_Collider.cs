using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Collider : MonoBehaviour {
    public BoxCollider2D deathCollider;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		deathCollider.transform.position = new Vector3(0, Camera.main.transform.position.y -9.5f, deathCollider.transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("triggered");
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        player.death();
    }
}
