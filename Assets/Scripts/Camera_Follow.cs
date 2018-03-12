using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {
    public Vector3 offset;
    public GameObject player;
    private float floor;
    public StatCounter stats;
    private int updates;
    private GameObject ceiling;
	// Use this for initialization
	void Start () {
        updates = 0;
        //asignamos a floor la altura del jugador
        floor = player.transform.position.y;
        //buscamos los objetos ceiling y stats para usarlos despues
        ceiling = GameObject.Find("Ceiling");
        stats = GameObject.Find("Stats").GetComponent<StatCounter>();
    }
	
	// Update is called once per frame
	void Update () {
        //si la posición en y del jugador es mayor que floor y la posición en y de la camara es menor que ceiling 
        if (floor < player.transform.position.y && Camera.main.transform.position.y < (ceiling.transform.position.y-offset.y))
        {
            //incrementamos nuestro contador updates
            updates++;
            //si el contador alcanza a 60
            if (updates == 60)
            {
                //incrementamos nuestros puntos
                stats.points+=10;
                //y reiniciamos el contador a 60
                updates = 0;
            }
            //Modificamos la posición de la camara a nuestra nueva altura
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);
            //guardamos la altura como floor, para que no se pueda bajar
            floor = Camera.main.transform.position.y;
        }
    }
}
