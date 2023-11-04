using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject player;
    public Sprite earth;
    public int velocy, spacing;
    float theta = Mathf.PI / 4; 
    public float thetaChange;
    double x, y;
    private float expandedRadius;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the arc that the player will be moving along, using the the earth + spacing
        //Spacing is / 100, to have more precision
        expandedRadius = (float) (.5 + spacing/100);
        Debug.Log(0);
    }

    // Update is called once per frame
    void Update()
    {

        switch (Input.GetAxis("Horizontal"))
        {
            //Right
            case 1:
                if (theta == 0)
                    break;
                theta -= (thetaChange/360) * 2*Mathf.PI;
                break;
            //Left
            case -1:
                if (theta == Mathf.PI)
                    break;
                theta += (thetaChange/360) * 2*Mathf.PI;
                break;
            default:
                break;
        }
        player.transform.position = new Vector2(expandedRadius * Mathf.Cos(theta), expandedRadius * Mathf.Sin(theta));
        //Debug.Log(Input.GetAxis("Horizontal") + ":" + theta + ":");

    }
}
