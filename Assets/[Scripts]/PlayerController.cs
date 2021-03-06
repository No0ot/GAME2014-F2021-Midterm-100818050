//      Author          : Chris Tulip , Tom Tsiliopoulos
//      StudentID       : 100818050
//      Date Modified   : October 20, 2021
//      File            : PlayerController.cs
//      Description     : This controls the player and updates the player based on screen orientation
//      History         : v1.0 - Implemented switch case on start to change the initial position and rotation based on screen orientation
//                        v0.9 - Duplicated and edited functions in update to reflect a landscape orientation, switches between them based on screen orientation
//
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float horizontalBoundary;

    [Header("Player Speed")]
    public float horizontalSpeed;
    public float maxSpeed;
    public float horizontalTValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
        
        // Switch case on start to set the position and rotation of the player based on screen orientation
        switch (Screen.orientation)
        {
            case ScreenOrientation.Landscape:
                transform.position = new Vector3(-3f,0f,0f);
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case ScreenOrientation.Portrait:
                transform.position = new Vector3(0f, -4f, 0f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
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
        _FireBullet();
    }

     private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.x > transform.position.x)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.x < transform.position.x)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Horizontal") >= 0.1f) 
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.x != 0.0f)
        {
           transform.position = new Vector2(Mathf.Lerp(transform.position.x, m_touchesEnded.x, horizontalTValue), transform.position.y);
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }
    /// <summary>
    /// Function for moving the player in Landscape Orientation
    /// </summary>
    private void _MoveY()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Vertical") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.y != 0.0f)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, horizontalTValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * horizontalSpeed);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, 0.0f);
        }

        // check left bounds
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0.0f);
        }

    }
    /// <summary>
    /// Function for checking the bounds for landscape orientation
    /// </summary>
    private void _CheckBoundsY()
    {
        // check right bounds
        if (transform.position.y >= horizontalBoundary)
        {
            transform.position = new Vector3(transform.position.x, horizontalBoundary, 0.0f);
        }

        // check left bounds
        if (transform.position.y <= -horizontalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -horizontalBoundary, 0.0f);
        }

    }
}
