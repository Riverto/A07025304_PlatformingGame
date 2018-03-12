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
        floor = player.transform.position.y;
        ceiling = GameObject.Find("Ceiling");
	}
	
	// Update is called once per frame
	void Update () {
        if (floor < player.transform.position.y && Camera.main.transform.position.y < (ceiling.transform.position.y-offset.y))
        {
            stats = GameObject.Find("Stats").GetComponent<StatCounter>();
            updates++;
            if (updates == 60)
            {
                stats.points+=10;
                updates = 0;
            }
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);
            floor = Camera.main.transform.position.y;
        }
    }
}
