using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent buttonpressed;
    public void Activated()
    {
        buttonpressed.Invoke();
    }
}
