using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEndZoneTrigger : MonoBehaviour
{
    public Light finish_zone_light;
    string sceneName;
    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    }

    // used for light trigger
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
