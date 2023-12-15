using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public SceneManagerHelper sceneManager;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = SceneManagerHelper.GetPlayerHealth();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        SceneManagerHelper.SetPlayerHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player is Dead!");
        }
    }
}
