using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanets : MonoBehaviour
{
    public class createPlanet
    {
        public string name;
        public float mass;
        public float radius;


        public createPlanet(string name, float mass, float radius)
        {
            this.name = name;
            this.mass = mass;
            this.radius = radius;
        }
    }

    int timeInterval = 10;
    public GameObject planet;
    int previousTime;

    //https://nssdc.gsfc.nasa.gov/planetary/factsheet/
    float[] masses = { 0.330 * Mathf.Pow(10, 24), 4.87 * Mathf.Pow(10, 24), 0.642 * Mathf.Pow(10, 24), 1898 * Mathf.Pow(10, 24), 568 * Mathf.Pow(10, 24), 86.8 * Mathf.Pow(10, 24), 102 * Mathf.Pow(10, 24) }; //in kgs
    string[] names = { "Mercury", "Venus", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };
    float[] radius = { 2439.5, 6052, 3396, 71492, 60268, 25559, 24764 }; // in km

    void makeList()
    {
        for (int i = 0; i < masses.len; i++)
        {
            createPlanet(names[i], masses[i], radius[i]);
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < masses.len; i++)
        {
            if ((int)Time.time % timeInterval == 0 && (int)Time.time != 0 && (int)Time.time != previousTime)
            {
                Debug.Log(createPlanet[i]);
                Instantiate(planet);
            }
            previousTime = (int)Time.time;
        }
        
    }
}