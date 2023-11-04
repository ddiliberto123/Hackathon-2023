using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject earth;
    public float radius = 2.5f;
    public float moveSpeed = 5f;
    //make sure z is 0
    private Vector3 center;
    private float angle = 20.41114f;


    void Start()
    {
        center = new Vector3(0f, -5f, 0f); // Set the desired initial position
        transform.position = center;
    }

    void Update()
    {
        // Handle keyboard input for left and right movement.
        float horizontalInput = Input.GetAxis("Horizontal");

        angle -= horizontalInput * moveSpeed * Time.deltaTime;

        // Constrain the angle within the specified range.
        angle = Mathf.Clamp(angle, 19.3f, 21.5f);

        // Calculate the new position
        float newX = center.x + Mathf.Cos(angle) * radius;
        float newY = center.y + Mathf.Sin(angle) * radius;
        Vector3 newPosition = new Vector3(newX, newY, transform.position.z);

        // Update the position.
        transform.position = newPosition;

        // Calculate the z-rotation based on the movement angle.
        float rotationAngle = Mathf.Rad2Deg * angle;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }
}