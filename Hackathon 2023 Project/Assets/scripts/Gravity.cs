using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    float G = 6.674f * Mathf.Pow(10, -11);
    Vector2 force;

    public float mass;
    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //returns gravitational force applied to the object
    public Vector2 gravitationalForce(float massObject,Vector2 positionObject)
    {
        force.x = G*massObject*mass/Mathf.Pow(positionObject.x-position.x,2);
        force.y = G * massObject * mass / Mathf.Pow(positionObject.y - position.y, 2);
        return new Vector2(force.x, force.y);
    }
}
