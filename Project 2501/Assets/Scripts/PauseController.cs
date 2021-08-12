using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    #region Variables
    public GameObject pausePanel;

    public Button resumeBtn;
    public Button quitBtn;
    public string menuScene;

    private bool isPaused;
    #endregion

    #region Built In Methods
    private void Start()
    {
        isPaused = false;

        resumeBtn.onClick.AddListener(ResumeGame);
        quitBtn.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        if (isPaused)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                ResumeGame();
            }
        }

        if (!isPaused)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                PauseGame();
            }
        }
    }
    #endregion

    #region Custom Methods
    private void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        pausePanel.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        pausePanel.SetActive(false);
    }

    private void QuitGame()
    {
        SceneManager.LoadScene(menuScene);
    }
    #endregion
}
