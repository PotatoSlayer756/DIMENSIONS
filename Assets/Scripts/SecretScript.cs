using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SecretScript : MonoBehaviour
{
    public Vector3 objposition;
    public float speed;
    [HideInInspector]
    public GameObject Player;
    [SerializeField] private AudioClip foundSoundClip;
    [SerializeField] private AudioClip lostSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        objposition = gameObject.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject;
            PickedUpByPlayer();
        }
    }

    public void PickedUpByPlayer()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3, Player.transform.position.z);
        gameObject.transform.parent = Player.gameObject.transform;
        AudioManager.Instance.PlaySoundClip(foundSoundClip, transform, 1f);
    }

    public void MoveBack()
    {
        gameObject.transform.parent = null;
        gameObject.transform.DOMove(objposition, speed);
        AudioManager.Instance.PlaySoundClip(lostSoundClip, transform, 1f);

    }

}
