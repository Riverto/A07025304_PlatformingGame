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
        //Si la velocidad del jugador es positiva, ignoramos la colision con
        //las plataformas
        Physics2D.IgnoreLayerCollision(8, 9, (playerBody.velocity.y > 0.0f));

        //cuando se presiona Z
        if (Input.GetKey(KeyCode.Z))
        {
            if (!isJumping) //si no se esta saltando actualmente
            {
                if (playerBody.velocity.y == 0) // y la velocidad del jugador
                    //en x es 0
                {
                    //entonces estamos saltando
                    isJumping = true;
                    //y agregamos una fuerza en y
                    playerBody.AddForce(new Vector2(0, yJumpForce));
                }
            }
        }
        else isJumping = false;//si no se presiona z entonces no estamos saltando
        if (!isJumping)//si no estamos saltando
        {
            //forzamos una gravedad constante en el jugador
            playerBody.velocity = new Vector2(playerBody.velocity.x, -9.81f);
        }

        //si se deja de presionar izquierda
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //cambiamos los booleanos para que ocurra la animacion de idle
            //a la izquierda
            anim.SetBool("walksLeft", false);
            anim.SetBool("idlesRight", false);
            anim.SetBool("idlesLeft", true);
        }
        //si se deja de presionar derecha
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //cambiamos los booleanos para que ocurra la animacion de idle
            //a la derecha
            anim.SetBool("walksRight", false);
            anim.SetBool("idlesLeft", false);
            anim.SetBool("idlesRight", true);
        }
        //si se presiona izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //cambiamos los booleanos para que ocurra la animacion de caminar
            //a la izquierda
            anim.SetBool("idlesLeft", false);
            anim.SetBool("idlesRight", false);
            anim.SetBool("walksLeft", true);
            //y movemos el sprite
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            //si se presiona derecha
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //cambiamos los booleanos para que ocurra la animacion de caminar
                //a la derecha
                anim.SetBool("idlesLeft", false);
                anim.SetBool("idlesRight", false);
                anim.SetBool("walksRight", true);
                //y movemos el sprite
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }

        //si la velocidad en y es menor a 0
        if (playerBody.velocity.y <= 0)
        {
            //cambiamos los booleanos para que no ocurra la animacion de salto
            anim.SetBool("jumpLeft", false);
            anim.SetBool("jumpRight", false);
        }

        //si la velocidad en y es diferente de 0 y estamos saltando
        if (playerBody.velocity.y != 0 && isJumping)
        {
            //si esta caminando a la derecha o idle a la derecha
            if (anim.GetBool("walksRight") || anim.GetBool("idlesRight"))
            {
                //cambiamos los booleanos para que ocurra la animacion de saltar
                //a la derecha
                anim.SetBool("jumpLeft", false);
                anim.SetBool("jumpRight", true);
            }
            else if (anim.GetBool("walksLeft") || anim.GetBool("idlesLeft"))
                //si esta caminando a la izquierda o idle a la izquierda
            {
                //cambiamos los booleanos para que ocurra la animacion de saltar
                //a la izquierda
                anim.SetBool("jumpLeft", true);
                anim.SetBool("jumpRight", false);
            }
        }
    }
    
    //cuando el jugador muere
    public void death()
    {
        //llamamos el metodo playerDied en levelManager
        levelManager.playerDied();
    }

    //cuando el jugador llega a una puerta
    public void nextLevel()
    {
        //llamamos el metodo playerReachedDoor en levelManager
        levelManager.playerReachedDoor();
    }
}
