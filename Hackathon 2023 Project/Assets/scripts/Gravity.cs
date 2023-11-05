using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    float G = 1;
    Vector2 force;

    public float mass;
    Vector2 position;

    float massObject;
    Vector2 positionObject;

    // Start is called before the first frame update
    void Start()
    {
        position = GetComponentInParent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "missile")
        {
            //get mass and position of missile
            massObject = collision.gameObject.GetComponent<Projectile>().mass;
            positionObject = collision.gameObject.GetComponent<Projectile>().transform.position;

            //apply force to missile
            collision.gameObject.GetComponent<Projectile>().applyForce(gravitationalForce(massObject, positionObject);
        }
        if (collision.gameObject.tag == "asteroid")
        {
            //get mass and position of asteroid
            massObject = collision.gameObject.GetComponent<Asteroid>().mass;
            positionObject = collision.gameObject.GetComponent<Asteroid>().transform.position;

            //apply force to asteroid
            collision.gameObject.GetComponent<Asteroid>().applyForce(gravitationalForce(massObject, positionObject);
        }
    }

    //returns gravitational force applied to the object
    public Vector2 gravitationalForce(float massObject,Vector2 positionObject)
    {
        force.x = -G * massObject * mass / Mathf.Pow(positionObject.x - position.x, 2);
        force.y = -G * massObject * mass / Mathf.Pow(positionObject.y - position.y, 2);
        return new Vector2(force.x, force.y);
    }
}
