/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioController : MonoBehaviour
{
    #region Variables
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource voiceSource;

    public AudioClip ButtonHighlightedWAV;
    public AudioClip ButtonPressedWAV;
    #endregion

    #region Built In Methods

    #endregion

    #region Custom Methods
    public void ButtonHighlighted()
    {
            sfxSource.PlayOneShot(ButtonHighlightedWAV);
    }

    public void ButtonPressed()
    {
        sfxSource.PlayOneShot(ButtonPressedWAV);
    }

    public void PlayClip(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    #endregion
}