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
    GameObject[] gravityZones;

    void Start()
    {
        player = GameObject.Find("Player");

        //set list of gravity zones
        gravityZones = GameObject.FindGameObjectsWithTag("gravity well");
        Debug.Log("graity zones: "+gravityZones.Length);

        position = player.transform.position;

        //set velocity of projectile using position of player
        directon = Mathf.Atan2(player.transform.position.y, player.transform.position.x);
        velocity = new UnityEngine.Vector2(speed * Mathf.Cos(directon), speed * Mathf.Sin(directon));

        transform.position = position;
    }

    void Update()
    {
        //add gravitational force from each gravity zone
        netForce = UnityEngine.Vector2.zero;
        for (int i = 0; i < gravityZones.Length; i++)
        {
            netForce += gravityZones[i].GetComponent<Gravity>().gravitationalForce(mass, position);
        }

        //use f=ma to calculate acceleration
        acceleration.x = netForce.x / mass;
        acceleration.y = netForce.y / mass;

        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
        position.x += velocity.x * Time.deltaTime;
        position.y += velocity.y * Time.deltaTime;
        transform.position = position;


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "asteroid":
                Destroy(gameObject);
                Destroy(collision.gameObject);
                break;
            case "missile":
                break;
            case "earth":
                break;
            default:
                Destroy(gameObject);
                break;
        }

        Debug.Log("collision!");
        // Check if the collision is with an object tagged as "earth"
    }
}
