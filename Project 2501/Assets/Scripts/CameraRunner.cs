using UnityEngine;

public class CameraRunner : MonoBehaviour
{
    public float speed = 10f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}