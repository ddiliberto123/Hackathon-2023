using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Planet : MonoBehaviour
{
    float mass;
    float radius;
    Vector2 position;
    string planetName;
    public Sprite sprite;

    int xBound;
    int yBound;

    void Start()
    {
        //set random position
        position = new Vector2(UnityEngine.Random.Range(-xBound, xBound), UnityEngine.Random.Range(-yBound, yBound));

        if (planetName == "Mars")
        {
            //set sprite to Mars' sprite
            mass = 100;
            radius = 3f;
        } else if (planetName == "Venus")
        {
            //set sprite to Venus' sprite
            mass = 50;
            radius = 2f;
        } else if (planetName == "Saturn")
        {
            //set sprite to Saturn' sprite
            mass = 300;
            radius = 5f;
        }
    }

    void Update()
    {
        
    }
}
