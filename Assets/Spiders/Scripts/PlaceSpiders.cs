using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSpiders : MonoBehaviour
{

    public GameObject gameObjectToClone;
    public int numberOfClones = 50;
    public float spawnRadius = 50;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GenerateClones();
    }

    void GenerateClones()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned. Please assign the player GameObject.");
            return;
        }

        for (int i=0; i< numberOfClones; i++)
        {

            Vector3 playerPosition = player.transform.position;

            Vector3 randomPos = GetRandomPos();

            GameObject clone = Instantiate(gameObjectToClone, randomPos + new Vector3(playerPosition.x, 0, playerPosition.y), Quaternion.identity);
        }
    }

    Vector3 GetRandomPos()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 randomPos = new Vector3(randomCircle.x, 0f, randomCircle.y); 

        randomPos.y = 0.5f;

        return randomPos;
    }
}
