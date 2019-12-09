using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code in this section taken from https://learn.unity.com/tutorial/character-controller-and-keyboard-input?courseId=5c5c1e08edbc2a5465c7ec01&projectId=5c6166dbedbc2a0021b1bc7c
public class LinkController : MonoBehaviour
{
    int maxHealth = 5;
    float speed = 3.0f;
    public GameObject projectilePrefab;			// Projectile weapon that the Main Character uses for attacks set in the scene.
    float timeInvincible = 2.0f;

    int currentHealth;
    bool isInvincible;							// Bool that checks if the player is invincible for a limited amount of time.
    float invincibleTimer;						// Time that the player is temporarily invincible.
    Vector2 lookDirection = new Vector2(1,0);

    public int health{get {return currentHealth;}}

    Rigidbody2D rigidbody2d;					// Variable that stores the rigidbody attribute to make the main character impassable.
    Animator animator;							// Animator variable for main character.

    //Boundries variables
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private string scene;

    // Start is called before the first frame update
    void Start()
    {
    	rigidbody2d = GetComponent<Rigidbody2D>();
    	currentHealth = maxHealth;							// Setting current health to the players max health initially.
    	animator = GetComponent<Animator>();				// Sets the animator variable.
    	this.tag = "Player";								// Sets the tag for the player.
    	scene = SceneManager.GetActiveScene().name;			// Gets the current game scene.


      //start boundries
      screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
      objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
      objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {

    	float horizontal = Input.GetAxis("Horizontal");
    	float vertical = Input.GetAxis("Vertical");

    	Vector2 move = new Vector2(horizontal, vertical);

    	// This code checks if the player is moving and if not, the players look direction is set to the current direction.
    	if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)){
    		lookDirection.Set(move.x, move.y);
    		lookDirection.Normalize();
    	}
    	// This block of code sets the animation variables for the character.
    	animator.SetFloat("Look X", lookDirection.x);		
    	animator.SetFloat("Look Y", lookDirection.y);
    	animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;				// Characters current position

        position = position + move * speed * Time.deltaTime;	// Updating characters positon
        rigidbody2d.MovePosition(position);

        if(isInvincible){
        	invincibleTimer -= Time.deltaTime;
        	if(invincibleTimer < 0){
        		isInvincible = false;
        	}
        }

        // Attack command for main character which is set to the C character.
        if(Input.GetKeyDown(KeyCode.C)){
        	Launch();
        }

        //Boundries for map
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -0.9f + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1.2f + objectHeight, screenBounds.y + objectWidth);
        transform.position = viewPos;
    }

    // This code changes the health of the character by the amount given within the parameter.
    // If the player takes damage, it also temporarily makes the character invincible based on the timer variable.
    public void changeHealth(int amount){

    	if(amount < 0){
    		if(isInvincible)
    		return;

    		isInvincible = true;
    		invincibleTimer = timeInvincible;
    		animator.SetTrigger("Hit");
    	}

    	currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);		// Update current health with a floor of zero.

      //Check game over
      if(currentHealth == 0){
        SceneManager.LoadScene("GameOver");
        Debug.Log("Health zero");
      }
    }

    // This function throws a projectile originating from the characters position into the direction they are facing.
    void Launch(){
    	GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
    	Projectile projectile = projectileObject.GetComponent<Projectile>();
    	projectile.Launch(lookDirection, 300);
    	//animator.SetTrigger("Launch");
    }

    // Save players current info.
    public void SavePlayer(){
    	GameObject player = GameObject.FindWithTag("Player");
    	SaveSystem.SavePlayer(this.gameObject);
    	Debug.Log("Saving game");
    }

    // Load players info based on most current save.
    public void LoadPlayer(){
    	PlayerData data = SaveSystem.LoadPlayer();
    	currentHealth = data.health;
    	Vector2 position;
    	position.x = data.position[0];
    	position.y = data.position[1];
    	transform.position = position;
    	SceneManager.LoadScene(data.scene);
    	Debug.Log(currentHealth + ", " + position.x + ", " + position.y);

    }

    public string getScene(){
    	return scene;
    }

    public int getMaxHealth(){
    	return maxHealth;
    }
}
