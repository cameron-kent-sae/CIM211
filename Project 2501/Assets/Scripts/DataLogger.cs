using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    #region Variables
    public PlayerEvolutionManager player;

    public TMP_Text textLog;
    public GameObject logPanel;
    public TMP_Text allCount;
    public TMP_Text divCount;
    public TMP_Text insCount;

    private List<string> eventLog = new List<string>();
    private string guiText = "";
    private int maxLInes = 40;

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
            openedPos = closedPos + 450;

        }
        else if  (Screen.width.Equals(1280))
        {
            openedPos = closedPos + 300;
        }
    }

    private void Update()
    {
        allCount.text = player.allegiantCount.ToString();
        divCount.text = player.divergentCount.ToString();
        insCount.text = player.insurgentCount.ToString();

        if (isExpanded)
        {
            if (Input.GetButtonDown("Tab"))
            {
                CloseLog();
            }
        }
        else if (!isExpanded)
        {
            if (Input.GetButtonDown("Tab"))
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