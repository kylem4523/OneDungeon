using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGame : MonoBehaviour
{

  public GameObject completeUI;

  void Update(){
    //Get Enemy objects through tag. If they are all destryed winning panel will pop up
    if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0){
      completeUI.SetActive(true);
    }
  }
}
