using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemController : MonoBehaviour
{
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
        // Retrieve the name of the active scene
        sceneName = SceneManagerHelper.GetActiveSceneName();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.name.Contains("Player"))
        {

            if (sceneName == "Mars")
            {
                SceneManagerHelper.isMarsGemAquired = true;
            }
            else if (sceneName == "Moon")
            {
                SceneManagerHelper.isMoonGemAquired = true;
            }
            FindObjectOfType<AudioManager>().Play("got_gem");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"Collided with object with tag: {other.gameObject.name}");
        }

    }

   
}


    
