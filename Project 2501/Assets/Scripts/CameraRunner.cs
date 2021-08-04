using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunner : MonoBehaviour
{
    public float speed;

    private Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
        rbody.velocity = transform.forward * speed;
    }
}
