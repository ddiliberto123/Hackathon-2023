using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanets : MonoBehaviour
{
    int timeInterval = 10;
    public GameObject planet;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //if time since game start is a multiple of time interval then spawn planet
        //Instantiate(planet);
    }
}
