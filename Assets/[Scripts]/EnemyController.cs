//      Author          : Chris Tulip , Tom Tsiliopoulos
//      StudentID       : 100818050
//      Date Modified   : October 20, 2021
//      File            : EnemyController.cs
//      Description     : This controls the enemy behaviour
//      History         : v1.0 - Implented additonal functions and applied them based on screen orientation
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    public float direction;
    private void Start()
    {
        // Switch case on start to set the position and rotation of the enemy based on screen orientation
        switch (Screen.orientation)
        {
            case ScreenOrientation.Landscape:
                transform.position = new Vector3(transform.position.y, transform.position.x, 0.0f);
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case ScreenOrientation.Portrait:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Switch case to switch between functionalitys based on screen orientation
        switch (Screen.orientation)
        {
            case ScreenOrientation.Landscape:
                _MoveY();
                _CheckBoundsY();
                break;
            case ScreenOrientation.Portrait:
                _Move();
                _CheckBounds();
                break;
        }
    }

    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed * direction * Time.deltaTime, 0.0f, 0.0f);
    }
    /// <summary>
    /// Function for moving the enemy in Landscape Orientation
    /// </summary>
    private void _MoveY()
    {
        transform.position += new Vector3(0.0f, horizontalSpeed * direction * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.x >= horizontalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.x <= -horizontalBoundary)
        {
            direction = 1.0f;
        }
    }
    /// <summary>
    /// Function for checking the bounds for landscape orientation
    /// </summary>
    private void _CheckBoundsY()
    {
        // check right boundary
        if (transform.position.y >= horizontalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -horizontalBoundary)
        {
            direction = 1.0f;
        }
    }
}
