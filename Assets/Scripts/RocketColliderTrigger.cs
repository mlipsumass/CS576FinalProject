using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEndZoneTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name.Contains("Player"))
        {
            Debug.Log("Collision with the player and cylinder");
            SceneManagerHelper.changeSceneTriggered = true;
            
        }
        else
        {
            Debug.Log($"Collided with object with tag: {other.gameObject.name}");
        }
    }
}
