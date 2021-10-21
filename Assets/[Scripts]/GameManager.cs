//      Author          : Chris Tulip
//      StudentID       : 100818050
//      Date Modified   : October 20, 2021
//      File            : GameManager.cs
//      Description     : This Controls general gameplay variables,in this case just the camera
//      History         : v1.0 - Implented change to camera based on on screen orientation
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    // Update is called once per frame
    void Update()
    {
        // I found when switching between the orientations the camera needed to update the orthographic size to fit the phone screen.
        switch (Screen.orientation)
        {
            case ScreenOrientation.Landscape:
                camera.orthographicSize = 2.4f;
                break;
            case ScreenOrientation.Portrait:
                camera.orthographicSize = 5.0f;
                break;
        }
    }

}
