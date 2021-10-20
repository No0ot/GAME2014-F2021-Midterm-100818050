using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera camera;

    // Update is called once per frame
    void Update()
    {
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
