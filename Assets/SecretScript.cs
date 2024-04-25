using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SecretScript : MonoBehaviour
{
    public Vector3 objposition;
    public float speed;
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
            gameObject.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 3, collision.transform.position.z);   
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }
    public void MoveBack()
    {
        gameObject.transform.parent = null;
        gameObject.transform.DOMove(objposition, speed);
    }

}
