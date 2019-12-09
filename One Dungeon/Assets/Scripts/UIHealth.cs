using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Class that presents the characters health
public class UIHealth : MonoBehaviour
{
    public Sprite[] heartSprites;		// Array that stores the different sprites for different health.
    public Image healthUI;				// Image that is actually displayed.
    private LinkController player;		// Variable for accessing players health.

    void Start(){
    	player = GameObject.FindWithTag("Player").GetComponent<LinkController>();		// Get the player object.
    }

    void Update(){
    	healthUI.sprite = heartSprites[player.health];		// Set the Health Sprite to the players current health.
    }
}
