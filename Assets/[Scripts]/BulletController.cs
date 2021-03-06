//      Author          : Chris Tulip , Tom Tsiliopoulos
//      StudentID       : 100818050
//      Date Modified   : October 20, 2021
//      File            : BulletController.cs
//      Description     : This controls the bullet behaviour
//      History         : v1.0 - Implented additonal functions and applied them based on screen orientation
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{
    public float verticalSpeed;
    public float verticalBoundary;
    public BulletManager bulletManager;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        // Switch case on start to set the position and rotation of the bullet based on screen orientation
        switch (Screen.orientation)
        {
            case ScreenOrientation.Landscape:
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
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f) * Time.deltaTime;
    }
    /// <summary>
    /// Function for moving the bullet in Landscape Orientation
    /// </summary>
    private void _MoveY()
    {
        transform.position += new Vector3(verticalSpeed,0.0f , 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (transform.position.y > verticalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
    /// <summary>
    /// Function for checking the bounds for landscape orientation
    /// </summary>
    private void _CheckBoundsY()
    {
        if (transform.position.x > verticalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        bulletManager.ReturnBullet(gameObject);
    }

    public int ApplyDamage()
    {
        return damage;
    }
}
