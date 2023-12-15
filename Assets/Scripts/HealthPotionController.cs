using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class HealthPotionController : MonoBehaviour
{
    public string playerObjectName = "MarsPlayer";
    public float healthAmount = 20.0f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected "  + SceneManagerHelper.GetPlayerHealth());

        if (other.gameObject.name == playerObjectName)
        {
            Debug.Log("Player trigger entered");
            if (SceneManagerHelper.GetPlayerHealth() < 1.0f)
            {
                float newHealth = SceneManagerHelper.GetPlayerHealth() + healthAmount / 100.0f;
                SceneManagerHelper.SetPlayerHealth(newHealth);

                Destroy(gameObject);
                Debug.Log("Bottle destroyed");
            }
            else
            {
                Debug.Log("Do Not Need Health Potion");
            }
        } else
        {
            Debug.Log($"Collided with object with tag: {other.gameObject.name}");
        }
        
    }

    
}



