using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject[] Powerups;
    public Transform[] SpawnPoints;
    public float SpawnTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPowerUp());

    }

    public IEnumerator SpawnPowerUp()
    {

        yield return new WaitForSeconds(SpawnTimer);

        // Pick a random Powerup from the array
        GameObject powerUp = Powerups[Random.Range(0, Powerups.Length)];
        //  Debug.Log(Powerups[Random.Range(0, Powerups.Length)]);


        // Pick a random Spawnpoint to spawn at
        Transform spawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];


        // Instantiate the Powerup at the spawn point
        GameObject powerupInstance = Instantiate(powerUp, spawnPoint);

        // Run the Coroutine again
        StartCoroutine(SpawnPowerUp());
    }
}
