using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PacketTumbler : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
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
            transform.LeanRotateY(ySpin, spinTime).setEaseInOutBounce();
            transform.LeanRotateZ(zSpin, spinTime).setEaseInOutBounce();

            yield return new WaitForSeconds(spinTime);
        }
    }
}