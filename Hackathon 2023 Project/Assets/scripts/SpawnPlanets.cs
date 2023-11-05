using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPlanets : MonoBehaviour
{
    public class createPlanet
    {
        public string names;
        public double masses;
        public double radius;
        public GameObject planetObject;
        public Vector2 position;


        public createPlanet(string names, double masses, double radius, Vector2 position)
        {
            this.names = names;
            this.masses = masses;
            this.radius = radius;
            this.planetObject = new GameObject();
            this.position = position;
        }
    }

    public List<createPlanet> listPlanet;

    int timeInterval = 10;
    public GameObject[] activePlanets;
    int previousTime;

    float xBound = 5;
    float yBound = 5;

    //https://nssdc.gsfc.nasa.gov/planetary/factsheet/
    double[] masses = { 0.330 * Mathf.Pow(10, 24), 4.87 * Mathf.Pow(10, 24), 0.642 * Mathf.Pow(10, 24), 1898 * Mathf.Pow(10, 24), 568 * Mathf.Pow(10, 24), 86.8 * Mathf.Pow(10, 24), 102 * Mathf.Pow(10, 24) }; //in kgs
    string[] names = { "Mercury", "Venus", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };
    double[] radius = { 2439.5, 6052, 3396, 71492, 60268, 25559, 24764 }; // in km

    void makeList()
    {
        for (int i = 0; i < 7; i++)
        {
            listPlanet.Add(new createPlanet(names[i], masses[i], radius[i],new Vector2(Random.Range(-xBound,xBound), Random.Range(-yBound, yBound))));
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < 7; i++)
        {
            if ((int)Time.time % timeInterval == 0 && (int)Time.time != 0 && (int)Time.time != previousTime)
            {
                Debug.Log(listPlanet[i]);
                Instantiate(listPlanet[i].planetObject);
                activePlanets.Append<GameObject>(listPlanet[i].planetObject);
            }
            previousTime = (int)Time.time;
        }
        
    }
}