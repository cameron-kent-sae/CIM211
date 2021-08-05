using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PacketTumbler : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(BeginObjectRotate());
    }

    private IEnumerator BeginObjectRotate()
    {
        while (true)
        {
            float xSpin = Random.Range(0, 360);
            float ySpin = Random.Range(0, 360);
            float zSpin = Random.Range(0, 360);
            float spinTime = Random.Range(1f, 1.5f);

            transform.LeanRotateX(xSpin, spinTime).setEaseInOutBounce();
            transform.LeanRotateY(xSpin, spinTime).setEaseInOutBounce();
            transform.LeanRotateZ(xSpin, spinTime).setEaseInOutBounce();
            //transform.rotation = Quaternion.Euler(xSpin, ySpin, zSpin);

            yield return new WaitForSeconds(spinTime);
        }
    }
}
