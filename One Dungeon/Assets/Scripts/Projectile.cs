using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class contains the code for the projectiles that the character uses as a weapon.
// Code in this section take from https://learn.unity.com/tutorial/world-interactions-projectile?courseId=5c5c1e08edbc2a5465c7ec01&projectId=5c6166dbedbc2a0021b1bc7c#5d5e7ac3edbc2a00205a81b1
public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Awake is called after the start of the game.
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // The code inside here destroys the instance if the projectile goes 100 units away from its origin in order
    // to prevent performance issues from too many instances.
    void Update(){
    	if(transform.position.magnitude > 100.0f){
    		Destroy(gameObject);
    	}
    }

    // This function takes in the direction and force specified and propels the projectile with the velocity given
    // the parameters.
    public void Launch(Vector2 direction, float force){
    	rigidbody2d.AddForce(direction * force);
    }

    // If the projectile collides with an object the projectile is destroyed.
    void OnCollisionEnter2D(Collision2D other){
    	Debug.Log("Projectile Collision with " + other.gameObject);
    	Destroy(gameObject);
    }
  
}
