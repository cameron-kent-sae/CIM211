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
    #endregion

    #region Built In Methods
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PlayerPrefs.SetString("WinPath", "");
        PlayerPrefs.SetString("Difficulty", "");

        playBtn.onClick.AddListener(StartGame);
        creditsBtn.onClick.AddListener(LoadCredits);
        quitBtn.onClick.AddListener(Application.Quit);

        StartCoroutine(EnableButtons());
    }
    #endregion

    #region Custom Methods
    private IEnumerator EnableButtons()
    {
        yield return new WaitForSeconds(6);

        playBtn.interactable = true;
        creditsBtn.interactable = true;
        quitBtn.interactable = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(introScene);
    }

    private void LoadCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }
    #endregion
}