using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFPSShow : MonoBehaviour
{
    float fps;

    private void Update()
    {

        fps = 1 / Time.deltaTime;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, Screen.width, 25.0f), fps.ToString());
    }
}
