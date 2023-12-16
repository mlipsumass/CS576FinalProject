using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float currentHealth;

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

            SceneManagerHelper.HandleGameOver();
            Debug.Log("Player is Dead!");
        }
    }
}
