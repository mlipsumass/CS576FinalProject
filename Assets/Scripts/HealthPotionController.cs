using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class HealthPotionController : MonoBehaviour
{
    public float healthAmount = 20.0f;

    private void OnTriggerEnter(Collider other)
    {
   
        if (other.gameObject.name.Contains("Player"))
        {
            if (SceneManagerHelper.GetPlayerHealth() < 1.0f)
            {
                float newHealth = SceneManagerHelper.GetPlayerHealth() + healthAmount / 100.0f;
                SceneManagerHelper.SetPlayerHealth(newHealth);

                Destroy(gameObject);
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



