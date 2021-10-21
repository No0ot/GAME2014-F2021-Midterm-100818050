//      Author          : Chris Tulip , Tom Tsiliopoulos
//      StudentID       : 100818050
//      Date Modified   : October 20, 2021
//      File            : BackgroundController.cs
//      Description     : This controls the background behaviour
//      History         : v1.0 - Implented additonal functions and applied them based on screen orientation
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    private void Start()
    {
        // Switch case on start to set the position and rotation of the background based on screen orientation
        switch (Screen.orientation)
        {
            case ScreenOrientation.Landscape:
                transform.position = new Vector3(transform.position.y, transform.position.x, 0.0f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
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

    private void _Reset()
    {
        transform.position = new Vector3(0.0f, verticalBoundary);
    }
    /// <summary>
    /// Function to reset the background position for landscape orientation
    /// </summary>
    private void _ResetY()
    {
        transform.position = new Vector3(verticalBoundary, 0.0f);
    }

    private void _Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed) * Time.deltaTime;
    }
    /// <summary>
    /// Function for moving the background in Landscape Orientation
    /// </summary>
    private void _MoveY()
    {
        transform.position -= new Vector3(verticalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.y <= -verticalBoundary)
        {
            _Reset();
        }
    }
    /// <summary>
    /// Function for checking the bounds for landscape orientation
    /// </summary>
    private void _CheckBoundsY()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -verticalBoundary)
        {
            _ResetY();
        }
    }
}
