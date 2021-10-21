//      Author          : Chris Tulip
//      StudentID       : 100818050
//      Date Modified   : October 21, 2021
//      File            : UIScript.cs
//      Description     : This Controls a panel that changes its size based on the safe area of the screen
//      History         : v1.0 - Implented change to the RectTransform component on this object to reflect the safe area
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    RectTransform panelRect;

    private void Start()
    {
        panelRect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Sets a panel to be the size of the safe area, label objects are attached to this object.
        panelRect.offsetMin = new Vector2(Screen.safeArea.xMin, Screen.safeArea.yMin);
        panelRect.offsetMax = new Vector2(Screen.safeArea.xMax - Screen.width, Screen.safeArea.yMax - Screen.height);

    }
}
