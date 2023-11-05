using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroid;
    //speed for spawning
    public float spawnInterval = 1.0f;
    // spawn area  
    public Vector2 spawnArea = new Vector2(8.0f, 5.0f);
    //use to check 
    private float timeSinceLastSpawn = 0;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnAsteroid();
            timeSinceLastSpawn = 0;
        }
    } 

    void SpawnAsteroid()
    {
        //creating the random position
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(spawnArea.y, spawnArea.y+5));

        int randomIndex = Random.Range(0, asteroid.Length);

        Instantiate(asteroid[randomIndex], spawnPosition, Quaternion.identity);
    }
}
