using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Variables
    public Button playBtn;
    public Button creditsBtn;
    public Button quitBtn;

    public string introScene;
    public string creditsScene;

    public AudioClip ButtonHighlightedWAV;
    public AudioClip ButtonPressedWAV;
    public AudioClip MainMenuMusic;
    private AudioSource audioSource;
    #endregion

    #region Built In Methods
    private void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.loop = true;
        audioSource.PlayOneShot(MainMenuMusic);

        PlayerPrefs.SetString("WinPath", "");
        PlayerPrefs.SetString("Difficulty", "");

        playBtn.onClick.AddListener(StartGame);
        creditsBtn.onClick.AddListener(LoadCredits);
        quitBtn.onClick.AddListener(Application.Quit);
    }
    #endregion

    #region Custom Methods
    private void StartGame()
    {
        SceneManager.LoadScene(introScene);
    }

    private void LoadCredits()
    {
        SceneManager.LoadScene(creditsScene);
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
    #endregion





}