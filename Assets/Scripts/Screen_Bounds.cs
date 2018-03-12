using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Bounds : MonoBehaviour {
    public float leftConstraint = 0.0f;
    public float rightConstraint = 0.0f;
    public float buffer = 1.0f; // set this so the spaceship disappears offscreen before re-appearing on other side
    public float distanceZ = 10.0f;
    private Rigidbody2D playerBody;

    void Awake()
    {
        // set Vector3 to ( camera left/right limits, spaceship Y, spaceship Z )
        // this will find a world-space point that is relative to the screen

        // using the camera's position from the origin (world-space Vector3(0,0,0)
        //leftConstraint = Camera.main.ScreenToWorldPoint( new Vector3(0.0f, 0.0f, 0 - Camera.main.transform.position.z) ).x;
        //rightConstraint = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, 0.0f, 0 - Camera.main.transform.position.z) ).x;

        // using a specific distance
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        Debug.Log(leftConstraint + " , " + rightConstraint);
        playerBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (playerBody.position.x < leftConstraint - buffer) { // ship is past world-space view / off screen
            playerBody.position = new Vector2(rightConstraint, playerBody.position.y);  // move ship to opposite side
        }

        if (playerBody.position.x > rightConstraint + buffer) {
            playerBody.position = new Vector2(leftConstraint, playerBody.position.y);
        }
    }
}
