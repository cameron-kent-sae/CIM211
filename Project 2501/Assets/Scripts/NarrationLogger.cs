/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NarrationLogger : MonoBehaviour
{
    #region Variables
    public TMP_Text textLog;
    public GameObject logPanel;

    private List<string> eventLog = new List<string>();
    private string guiText = "";
    private float closedPos;
    private float openedPos;
    public bool isExpanded;
    #endregion

    #region Built In Methods
    private void Start()
    {
        eventLog.Clear();
        textLog.text = guiText;
        isExpanded = false;

        closedPos = logPanel.transform.position.x;
        if (Screen.width.Equals(1920))
        {
            openedPos = closedPos - 450;

        }
        else if (Screen.width.Equals(1280))
        {
            openedPos = closedPos - 300;
        }
    }

    private void Update()
    {
        if (isExpanded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                CloseLog();
            }
        }
        else if (!isExpanded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                OpenLog();
            }
        }
    }
    #endregion

    #region Custom Methods
    public void OpenLog()
    {
        logPanel.LeanMoveX(openedPos, .2f).setEaseInBounce();
        isExpanded = true;
    }

    public void CloseLog()
    {
        logPanel.LeanMoveX(closedPos, .2f).setEaseOutBounce();
        isExpanded = false;
    }

    public void AddLog(string newDataLog)
    {
        eventLog.Add(newDataLog);

        guiText = "";

        foreach (string log in eventLog)
        {
            guiText += log;
            guiText += "\n";
            guiText += "\n";
        }

        textLog.text = guiText;
    }

    #endregion
}