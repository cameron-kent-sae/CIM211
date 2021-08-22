/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetupController : MonoBehaviour
{
    #region Variables
    public Button fastBtn;
    public Button averageBtn;
    public Button slowBtn;

    public string gameScene;
    #endregion
        
    #region Built In Methods
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        fastBtn.onClick.AddListener(delegate { StartGame("Fast"); });
        averageBtn.onClick.AddListener(delegate { StartGame("Average"); });
        slowBtn.onClick.AddListener(delegate { StartGame("Slow"); });
    }
    #endregion

    #region Custom Methods
    private void StartGame(string speed)
    {

        switch (speed)
        {
            case "Slow":
                PlayerPrefs.SetString("Difficulty", "Slow");
                SceneManager.LoadScene(gameScene);
                break;
            case "Average":
                PlayerPrefs.SetString("Difficulty", "Average");
                SceneManager.LoadScene(gameScene);
                break;
            case "Fast":
                PlayerPrefs.SetString("Difficulty", "Fast");
                SceneManager.LoadScene(gameScene);
                break;
            default:
                break;
        }
    }
    #endregion
}