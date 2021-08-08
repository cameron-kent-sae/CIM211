using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPulser : MonoBehaviour
{
    private float approachSpeed = .3f;
    private float growthBound = 1.1f;
    private float shrinkBound = 0.8f;
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
        // Run this indefinitely
        while (keepGoing)
        {
            // Get bigger for a few seconds
            while (this.currentRatio != this.growthBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed * Time.deltaTime);

                // Update our text element
                this.transform.localScale = Vector3.one * currentRatio;
                //this.icon.text = "Growing!";

                yield return new WaitForEndOfFrame();
            }

            // Shrink for a few seconds
            while (this.currentRatio != this.shrinkBound)
            {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed * Time.deltaTime);

                // Update our text element
                this.transform.localScale = Vector3.one * currentRatio;
                //this.icon.text = "Shrinking!";

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
