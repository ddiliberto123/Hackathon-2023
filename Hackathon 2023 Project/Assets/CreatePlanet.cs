using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlanet 
{
    public double mass;
    public string name;
    public double radius;

    public void CreatePlanet()
    {
        CreatePlanet(0, "unknown", 0);
    }
    public void CreatePlanet(double mass, string name, double radius)
    {
        this.mass = mass;
        this.name = name;
        this.radius = radius;
    }
}
