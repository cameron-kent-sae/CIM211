/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFader : MonoBehaviour
{
    #region Variables
    public CanvasGroup canvasGroup;
    public float fadeLength = 3;
    public float fadeDelay;
    #endregion

    #region Built In Methods
    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Awake()
    {
        StartFade();
    }
    #endregion

    #region Custom Methods
    public void StartFade()
    {
        StartCoroutine("FadeInCanvas");
    }

    IEnumerator FadeInCanvas()
    {
        yield return new WaitForSeconds(fadeDelay);

        for (float t = 0f; t < fadeLength; t += Time.deltaTime)
        {
            canvasGroup.alpha = t;
            yield return null;
        }
    }
    #endregion
}