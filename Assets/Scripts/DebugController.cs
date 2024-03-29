using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    public bool consoleOn;

    string input;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            consoleOn = !consoleOn;
        }
    }
    private void OnGUI()
    {
        if(!consoleOn) { return; }
        float y = 0f;
        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width-20f, 20f), input);
    }
}
