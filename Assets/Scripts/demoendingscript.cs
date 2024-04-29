using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoendingscript : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            Application.Quit();
        }
    }
}
