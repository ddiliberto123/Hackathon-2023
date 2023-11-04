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

    void Start()
    {
        //To set rigid body
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Earth.transform.position, asteroidSpeed * Time.deltaTime);

    }

    // OnCollisionEnter2D is called when a collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision!");
        // Check if the collision is with an object tagged as "earth"
        if (collision.gameObject.CompareTag("earth"))
        {
            Destroy(Earth);

        }
    }

}
