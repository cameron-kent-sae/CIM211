using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    #region Variables
    public GameObject pausePanel;
    public DataLogger dataLogger;
    public NarrationLogger narrationLogger;

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
        if (Input.GetButtonDown("Cancel"))
        {
            if (!isPaused)
            {
                if (!narrationLogger.isExpanded) narrationLogger.OpenLog();
                if (!dataLogger.isExpanded) dataLogger.OpenLog();
                Invoke("PauseGame", .2f);
            }
            else if (isPaused)
            {
                ResumeGame();
            }
        }
    }
    #endregion

    #region Custom Methods
    private void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        Cursor.visible = true;
        pausePanel.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        Cursor.visible = false;
        pausePanel.SetActive(false);

        narrationLogger.CloseLog();
        dataLogger.CloseLog();
    }

    private void QuitGame()
    {
        SceneManager.LoadScene(menuScene);
    }
    #endregion
}