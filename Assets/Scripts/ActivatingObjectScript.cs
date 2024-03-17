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
        anim.SetTrigger("PlayerEnt");
    }
    public void Disactivated()
    {
        anim.SetTrigger("PlayerExi");
    }
}
