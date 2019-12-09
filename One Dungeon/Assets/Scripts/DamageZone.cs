using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code in this section taken from https://learn.unity.com/tutorial/world-interactions-damage-zones-and-enemies?courseId=5c5c1e08edbc2a5465c7ec01&projectId=5c6166dbedbc2a0021b1bc7c
public class DamageZone : MonoBehaviour
{
  // This will take out player health when player touches the spk
    void OnTriggerStay2D(Collider2D other)
    {
        LinkController controller = other.GetComponent<LinkController>();

        if (controller != null)
        {
            controller.changeHealth(-1);
        }
    }

}
