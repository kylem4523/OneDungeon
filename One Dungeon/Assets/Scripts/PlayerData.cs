using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class stores all of the players key data into a serializable format for saving and loading.
// Code in this section taken from https://www.youtube.com/watch?v=XOjd_qU2Ido
[System.Serializable]
public class PlayerData
{
    public int health;			// Player health.
    public float[] position;	// Players current x,y coordinates.
    public string scene;		// Current scene

    public PlayerData(GameObject player){
    	LinkController link = player.gameObject.GetComponent<LinkController>();			// This gets the main characters attributes for data manipulation.
    	health = link.health;
    	scene = link.getScene();
    	position = new float[2];
    	position[0] = player.transform.position.x;			// Players x coordinate
    	position[1] = player.transform.position.y;			// Players y coordinate
    }
}
