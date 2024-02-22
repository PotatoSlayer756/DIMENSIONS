using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject PanelMenu;
    TimerScript timerScript;

    private void Start()
    {
        PanelMenu.SetActive(false);
        timerScript = gameObject.GetComponent<TimerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            timerScript.StopTimer();
            PanelMenu.SetActive(true);
        }
    }
}
