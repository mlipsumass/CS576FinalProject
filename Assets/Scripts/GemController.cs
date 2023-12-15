using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Contains("Player"))
        {
            
            SceneManagerHelper.is_mars_gem_achieved = true;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"Collided with object with tag: {other.gameObject.name}");
        }

    }

   
}


    
