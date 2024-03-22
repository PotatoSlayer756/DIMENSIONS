using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingObjectScript : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Activated()
    {
        anim.SetBool("PlayerEnt", true);
    }
    public void Disactivated()
    {
        anim.SetBool("PlayerEnt", false);
    }
}
