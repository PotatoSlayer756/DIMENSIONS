using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShiftScript : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform newLookAt, newPosition;
    public Quaternion newRotation;
    public bool isItDefault, isPlayerIn = false;
    [HideInInspector]
    public Transform oldLookAt, oldFollow, oldPosition;
    [HideInInspector]
    public Quaternion oldRotation;
    void Start()
    {
        oldLookAt = virtualCamera.LookAt;
        oldFollow = virtualCamera.Follow;
        oldRotation = virtualCamera.transform.rotation;
        oldPosition = virtualCamera.gameObject.transform;
    }
    void MovePosition()
    {
        switch (isItDefault)
        {
            case true:
                virtualCamera.transform.DOMove(new Vector3(oldPosition.transform.position.x, oldPosition.transform.position.y, oldPosition.transform.position.z), 0.6f);
                virtualCamera.Follow = oldFollow;
                virtualCamera.transform.rotation = oldRotation;
                break;

            case false:
                if (!isPlayerIn)
                {
                    oldRotation = virtualCamera.transform.rotation;
                    virtualCamera.transform.DOMove(new Vector3(newPosition.transform.position.x, newPosition.transform.position.y, newPosition.transform.position.z), 0.6f);
                    virtualCamera.Follow = null;
                    virtualCamera.transform.rotation = newRotation;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MovePosition();
            isPlayerIn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isPlayerIn)
            {
                virtualCamera.transform.rotation = oldRotation;
                Debug.Log(oldRotation);
                virtualCamera.transform.DOMove(new Vector3(oldPosition.transform.position.x, oldPosition.transform.position.y, oldPosition.transform.position.z), 0.6f);
                virtualCamera.Follow = oldFollow;
                isPlayerIn = false;
            }
        }
    }
}
