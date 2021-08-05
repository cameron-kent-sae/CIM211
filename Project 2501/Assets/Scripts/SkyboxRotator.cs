using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", speed * Time.deltaTime);
    }
}
