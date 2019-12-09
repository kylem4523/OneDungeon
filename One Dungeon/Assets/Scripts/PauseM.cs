using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseM: MonoBehaviour{

      public static bool GameIsPaused = false;
      //this is for UI panel
      public GameObject pauseMenuUI;

        // Update is called once per frame

        void Update()
        {
          //When player hit "Escape" the view will pop up with resume/paused
            if(Input.GetKeyDown(KeyCode.Escape)){
              if(GameIsPaused){
                Resume();
              }
              else{
                 Pause();
              }
            }
        }

        //Button will be inactive if player hits resume
        public void Resume(){
          pauseMenuUI.gameObject.SetActive(false);
          Time.timeScale = 1f;
          GameIsPaused = false;

        }
        //Button will be active 
        void Pause(){
          pauseMenuUI.SetActive(true);
          Time.timeScale = 0f;
          GameIsPaused = true;

        }

        public void Save(){
            Debug.Log("Should save");
        }


        public void QuitGame(){
          SceneManager.LoadScene("mainmenu");

        }
    }
