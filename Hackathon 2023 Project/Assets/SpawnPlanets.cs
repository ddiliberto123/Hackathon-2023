using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanets : MonoBehaviour
{
    int timeInterval = 3;
    public GameObject planet;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if ((int)Time.time % timeInterval == 0 && (int)Time.time != 0)
        { 
            Debug.Log("spawn planet");
            Instantiate(planet);
        }
    }
}
