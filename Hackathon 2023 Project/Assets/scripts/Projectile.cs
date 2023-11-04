using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector2 position;
    Vector2 velocity;
    public float speed;
    float directon;
    GameObject player;

    public int xBound;
    public int yBound;

    void Start()
    {
        player = GameObject.Find("Player");
        position = player.transform.position;

        //set velocity of projectile using position of player
        directon = Mathf.Atan2(player.transform.position.y, player.transform.position.x);
        velocity = new Vector2(speed * Mathf.Cos(directon), speed * Mathf.Sin(directon));

        transform.position = position;
    }

    void Update()
    {
        //increment position using velocity
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
