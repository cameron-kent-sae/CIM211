/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromeAbAdjuster : MonoBehaviour
{
    #region Variables
    public PostProcessProfile profile;
    private ChromaticAberration chromeAb;
    #endregion

    #region Built In Methods
    private void Start()
    {
        chromeAb = profile.GetSetting<ChromaticAberration>();
        chromeAb.intensity.Override(.1f);
    }
    #endregion

    #region Custom Methods
    public void UpdateChromaticAberration(float newValue)
    {
        chromeAb.intensity.Override(Mathf.Lerp(chromeAb.intensity, newValue, 5f));
    }
    #endregion
}