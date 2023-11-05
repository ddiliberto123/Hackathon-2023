using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To make sure we have a rigid body!
[RequireComponent(typeof(Rigidbody2D))]

public class Asteroid : MonoBehaviour
{
    public GameObject Earth;
    private Rigidbody2D rb;
    public float mass = 1f;
    public float startSpeed = 1f;

    Vector2 netforce;
    Vector2 acceleration;
    Vector2 velocity;
    Vector2 position;
    float direction;

    void Start()
    {
        //To set rigid body
        rb = GetComponent<Rigidbody2D>();
        direction = Mathf.Atan2(Earth.transform.position.y - position.y, Earth.transform.position.x - position.x);
        velocity = new Vector2(startSpeed * Mathf.Cos(direction), startSpeed * Mathf.Sin(direction));
    }

    public void applyForce(Vector2 force)
    {
        netforce += force;
    }

    // Update is called once per frame
    void Update()
    {
        // F=ma
        acceleration = netforce / mass;

        //velocity += acceleration;
        position += velocity * Time.deltaTime;
        transform.position = position;
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
