using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataObject : MonoBehaviour
{
    public DataPacket data;
    private GameObject cameraObject;

    private void Start()
    {
        cameraObject = GameObject.Find("RunningCamera");
    }

    private void Update()
    {
        if (transform.position.z < (cameraObject.transform.position.z - 25))
        {
            Destroy(gameObject);
        }
    }
}