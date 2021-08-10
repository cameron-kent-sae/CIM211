using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using UnityEngine.EventSystems;



public class SceneManager1 : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip ButtonHighlightedWAV;
    public AudioClip ButtonPressedWAV;
    private AudioSource audioSource;


    //Selects Scene
    public void SceneSelector(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Exits Game
    public void Exit()
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();


    }

    public void ButtonHighlighted()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.PlayOneShot(ButtonHighlightedWAV);
    }

    public void ButtonPressed()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.PlayOneShot(ButtonPressedWAV);
    }


}
