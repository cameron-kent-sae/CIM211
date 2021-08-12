using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    #region Variables
    public TMP_Text textLog;
    public GameObject logPanel;
    public TMP_Text allCount;
    public TMP_Text divCount;
    public TMP_Text insCount;

    private List<string> eventLog = new List<string>();
    private string guiText = "";
    private int maxLInes = 40;
    private bool isExpanded;
    #endregion

    #region Built In Methods
    private void Start()
    {
        textLog.text = guiText;
        isExpanded = false;
    }

    private void Update()
    {
        if (isExpanded)
        {
            if (Input.GetButtonDown("Tab"))
            {
                logPanel.LeanMoveX(-175f, .2f).setEaseOutBounce();
                isExpanded = false;
            }
        }
        else if (!isExpanded)
        {
            if (Input.GetButtonDown("Tab"))
            {
                logPanel.LeanMoveX(270f, .2f).setEaseInBounce();
                isExpanded = true;
            }
        }
    }
    #endregion

    #region Custom Methods
    public void AddLog(string newDataLog)
    {
        eventLog.Add(newDataLog);

        if (eventLog.Count >= maxLInes)
        {
            eventLog.RemoveAt(0);
        }

        guiText = "";

        foreach (string log in eventLog)
        {
            guiText += log;
            guiText += "\n";
        }

        textLog.text = guiText;
    }
    #endregion
}