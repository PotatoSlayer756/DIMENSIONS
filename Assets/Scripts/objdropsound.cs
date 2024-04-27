using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stonedrop : MonoBehaviour
{
    public bool isStone;
    public AudioClip dropWoodsound, dropStonesound;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            if(isStone)
            {
                AudioManager.Instance.PlaySoundClip(dropStonesound, transform, 1f);
            }
            else
            {
                AudioManager.Instance.PlaySoundClip(dropWoodsound, transform, 1f);
            }
        }
    }
}
