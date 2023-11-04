using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    UnityEngine.Vector2 position;
    UnityEngine.Vector2 velocity;
    UnityEngine.Vector2 acceleration;
    UnityEngine.Vector2 force;
    public float mass;
    public float speed;
    float directon;
    GameObject player;

    //G controls the global strength of gravity
    float G = 1;

    //list of active planets
    public GameObject[] planets;

    public int xBound;
    public int yBound;

    void Start()
    {
        player = GameObject.Find("Player");
        position = player.transform.position;

        //set velocity of projectile using position of player
        directon = Mathf.Atan2(player.transform.position.y, player.transform.position.x);
        velocity = new UnityEngine.Vector2(speed * Mathf.Cos(directon), speed * Mathf.Sin(directon));

        transform.position = position;
    }

    void Update()
    {
        if (planets.Length > 0)
        {
            //iterate over list of planets and apply gravitational force from each to the projectile using Newton's law of gravity
            for (int i = 0; i < planets.Length; i++)
            {
                force.x = G * mass * planets[i].GetComponent<Planet>().mass / Mathf.Pow(planets[i].transform.position.x - position.x, 2);
                force.y = G * mass * planets[i].GetComponent<Planet>().mass / Mathf.Pow(planets[i].transform.position.y - position.y, 2);
            }
        }

        //set acceleration using F=ma
        acceleration.x = force.x / mass;
        acceleration.y = force.y / mass;

        //set velocity and position
        velocity.x = acceleration.x * Time.deltaTime;
        velocity.y = acceleration.y * Time.deltaTime;
        position.x += velocity.x * Time.deltaTime;
        position.y += velocity.y * Time.deltaTime;
        transform.position = position;

        //destroy projectile if out of bounds
        if (position.x > xBound || position.x < -xBound || position.y > yBound || position.y < -yBound)
        {
            Object.Destroy(gameObject);
        }
    }
}
