using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    UnityEngine.Vector2 position;
    UnityEngine.Vector2 velocity;
    UnityEngine.Vector2 acceleration;
    UnityEngine.Vector2 netForce;
    public float mass;
    public float speed;
    float directon;
    GameObject player;

    //list of active planets

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
        //old gravity code
        /*
         planets = GetComponent<SpawnPlanets>().activePlanets;
        netForce = new UnityEngine.Vector2(0,0);
        if (planets.Length > 0)
        {
            //iterate over list of planets and apply gravitational force from each to the projectile using Newton's law of gravity
            for (int i = 0; i < planets.Length; i++)
            {
                netForce.x += G * mass * planets[i].GetComponent<Planet>().mass / Mathf.Pow(planets[i].transform.position.x - position.x, 2);
                netForce.y += G * mass * planets[i].GetComponent<Planet>().mass / Mathf.Pow(planets[i].transform.position.y - position.y, 2);
            }
        }

        //set acceleration using F=ma
        acceleration.x = -netForce.x / mass;
        acceleration.y = -netForce.y / mass;

        //set velocity and position
        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
         */

        netForce = GetComponent<Gravity>().gravitationalForce(mass, position);
        acceleration.x = netForce.x / mass;
        acceleration.y = netForce.y / mass;
        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
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
