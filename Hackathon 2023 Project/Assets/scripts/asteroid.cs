using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To make sure we have a rigid body!
[RequireComponent(typeof(Rigidbody2D))]

public class Asteroid : MonoBehaviour
{
    public GameObject Earth;
    private Rigidbody2D rb;
    public float asteroidSpeed = 5.0f;
    public float mass = 1f;

    Vector2 netforce;
    Vector2 acceleration;

    void Start()
    {
        //To set rigid body
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void applyForce(Vector2 force)
    {
        netforce += force;
    }

    // Update is called once per frame
    void Update()
    {
        // F=ma
        acceleration = netforce/mass;

        asteroidSpeed += acceleration.magnitude;

        transform.position = Vector2.MoveTowards(transform.position, Earth.transform.position, asteroidSpeed * Time.deltaTime);
        netforce = Vector2.zero;
    }

    // OnCollisionEnter2D is called when a collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "planet":
                Destroy(gameObject);
                break;
            case "earth":
                Destroy(gameObject);
                Destroy(collision.gameObject);
                //Stage change
                break;
            default:
                Destroy(gameObject);
                Destroy(collision.gameObject);
                break;

        }
    }

}
