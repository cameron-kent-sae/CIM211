/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogController : MonoBehaviour
{
    #region Variables
    public DataInventory dataInventory;

    public GameObject logPanel;
    public TMP_Text textPrefab;

    public Button allegiantBtn;
    public Button divergentBtn;
    public Button insurgentBtn;
    public Button otherBtn;
    public Button creditsBtn;

    public string creditsScene;
    #endregion

    #region Built In Methods
    private void Start()
    {
        allegiantBtn.onClick.AddListener(delegate { ShowData("Allegiant"); });
        divergentBtn.onClick.AddListener(delegate { ShowData("Allegiant"); });
        insurgentBtn.onClick.AddListener(delegate { ShowData("Allegiant"); });
        otherBtn.onClick.AddListener(delegate { ShowData("Allegiant"); });
        creditsBtn.onClick.AddListener(LoadCredits);
    }
    #endregion

    #region Custom Methods
    private void ShowData(string path)
    {

    }

    private void LoadCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }
    #endregion
}