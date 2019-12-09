using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{
    float speed = 1.0f;			// Enemies speed attribute
    Transform target;			// Postion variable for the enemies target, i.e. the player. 
    int health = 3;				// Enemies health 

    Rigidbody2D rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;		// Setting target to player
        this.tag = "Enemy";											// Setting tag for any instance of this class to check later if win condition has been met.
    }

    // Update is called once per frame to update enemy position 
    void Update()
    {
        
        Vector2 position = rigidbody2D.position;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

   	// This function damages the player if the player and enemy collide and damages the enemy if the enemy
   	// and a projectile collide.
   	// Code in this sectionm was taken from https://learn.unity.com/tutorial/world-interactions-damage-zones-and-enemies?courseId=5c5c1e08edbc2a5465c7ec01&projectId=5c6166dbedbc2a0021b1bc7c
    void OnCollisionEnter2D(Collision2D other){
    	LinkController player = other.gameObject.GetComponent<LinkController>();
    	Projectile projectile = other.gameObject.GetComponent<Projectile>();
    	if(player != null){
    		player.changeHealth(-1);
    	}
    	if(projectile != null){
    		health -= 1;
    		if(health == 0){
    			Destroy(gameObject);		// Destroys the instance if they run out of health.
    		}
    	}
    }

    // Getter for health
    int getHealth(){
    	return health;
    }
}
