using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Health item class that acts as a trigger when the player collides with.
// Code in this sectionm taken from https://learn.unity.com/tutorial/world-interactions-collectibles?courseId=5c5c1e08edbc2a5465c7ec01&projectId=5c6166dbedbc2a0021b1bc7c
public class HealthCollectible : MonoBehaviour
{
	
	// Upon collision, will check if the player is below max health and if so, will 
	// increase the players health by 1 and then destroy the object instance. 
    void OnTriggerEnter2D(Collider2D other){
    	LinkController controller = other.GetComponent<LinkController>();
    	if(controller != null){
    		if(controller.health < controller.getMaxHealth()){
    			controller.changeHealth(1);
    			Destroy(gameObject);
    		}
    	}
    }
}
