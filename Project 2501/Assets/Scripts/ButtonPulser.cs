using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPulser : MonoBehaviour
{
    private float approachSpeed = .1f;
    private float growthBound = 1f;
    private float shrinkBound = 0.9f;
    private float currentRatio = 1;
    public bool keepGoing = true;

    void Awake()
    {
        StartCoroutine(Pulse());
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private IEnumerator Pulse()
    {
        while (keepGoing)
        {
            while (this.currentRatio != this.growthBound)
            {
                currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed * Time.deltaTime);
                this.transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }

            while (this.currentRatio != this.shrinkBound)
            {
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed * Time.deltaTime);
                this.transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }
        }
    }
}