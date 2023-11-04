using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

/**
public class Planet : MonoBehaviour
{
    public float mass;
    float radius;
    Vector2 position;
    string planetName;
    public Sprite sprite;

    int xBound = 5;
    int yBound = 5;

    void Start()
    {
        //set random position
        position = new Vector2(UnityEngine.Random.Range((float)-xBound, (float)xBound), UnityEngine.Random.Range((float)-yBound, (float)yBound));
        transform.position = position;

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
        else
        {
            mass = 100;
            radius = 1;
        }
        transform.localScale = new Vector2(radius, radius);
    }

    void Update()
    {
        
    }
}
**/
