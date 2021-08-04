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
        //rbody.velocity = transform.forward * speed;
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}