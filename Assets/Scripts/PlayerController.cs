using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 15.0f;     //	The speed at which the player moves
    private Animator anim;
    private Rigidbody2D playerBody;
    public float yJumpForce = 300f;
    public bool isJumping;
    public LevelManager levelManager;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        playerBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        anim.SetBool("idlesRight", true);
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    public void won()
    {
        levelManager.playerReachedTop();
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(playerBody.velocity.y);
        Physics2D.IgnoreLayerCollision(8, 9, (playerBody.velocity.y > 0.0f));

        if (Input.GetKey(KeyCode.Z))
        {
            if (!isJumping)
            {
                if (playerBody.velocity.y == 0)
                {
                    isJumping = true;
                    playerBody.AddForce(new Vector2(0, yJumpForce));
                }
            }
        }
        else isJumping = false;
        if (!isJumping)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, -9.81f);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("walksLeft", false);
            anim.SetBool("idlesRight", false);
            anim.SetBool("idlesLeft", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("walksRight", false);
            anim.SetBool("idlesLeft", false);
            anim.SetBool("idlesRight", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("idlesLeft", false);
            anim.SetBool("idlesRight", false);
            anim.SetBool("walksLeft", true);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("idlesLeft", false);
                anim.SetBool("idlesRight", false);
                anim.SetBool("walksRight", true);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        if (playerBody.velocity.y <= 0)
        {
            anim.SetBool("jumpLeft", false);
            anim.SetBool("jumpRight", false);
        }
        if (playerBody.velocity.y != 0 && isJumping)
        {
            if (anim.GetBool("walksRight"))
            {
                anim.SetBool("jumpLeft", false);
                anim.SetBool("jumpRight", true);
            }
            else if (anim.GetBool("walksLeft"))
            {
                anim.SetBool("jumpLeft", true);
                anim.SetBool("jumpRight", false);
            }
            else if (anim.GetBool("idlesLeft"))
            {
                anim.SetBool("jumpLeft", true);
                anim.SetBool("jumpRight", false);
            }
            else if (anim.GetBool("idlesRight"))
            {
                anim.SetBool("jumpLeft", false);
                anim.SetBool("jumpRight", true);
            }
        }
    }
    
    public void death()
    {
        levelManager.playerDied();
    }

    public void nextLevel()
    {        
        levelManager.playerReachedDoor();
    }
}
