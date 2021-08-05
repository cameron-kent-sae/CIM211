using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rbody;
    private Vector3 moveVelocity;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        /* AXIS movement
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        moveVelocity = moveInput.normalized * speed;
        */
    }

    private void FixedUpdate()
    {
        /* AXIS movement
        rbody.MovePosition(rbody.position + moveVelocity * Time.fixedDeltaTime); 
        */
    }
}
