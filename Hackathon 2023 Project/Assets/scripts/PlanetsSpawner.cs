using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsSpawn : MonoBehaviour
{
    public GameObject[] Planets;


    void Update()
    {
        float spawnInterval = 3.0f;
        float time = 0.0f;
        time += Time.deltaTime;

        if (spawnInterval % time == 0)
        {
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        //creating the random position
        Vector2 spawnPosition = new Vector2(300, 300);

        int randomIndex = Random.Range(0, Planets.Length);

        Instantiate(Planets[randomIndex], spawnPosition, Quaternion.identity);
    }
}
