/*
	Cameron Kent	2021
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogController : MonoBehaviour
{
    #region Variables
    public DataInventory dataInventory;

    public TMP_Text headerText;
    public TMP_Text logText;
    private List<string> eventLog = new List<string>();
    private string guiText = "";

    public Button allegiantBtn;
    public Button divergentBtn;
    public Button insurgentBtn;
    public Button otherBtn;
    public Button exportBtn;
    public Button creditsBtn;

    public string creditsScene;

    private string allegiantTitle = "Allegiant Data";
    private string divergentTitle = "Divergent Data";
    private string insurgentTitle = "Insurgent Data";
    private string otherTitle = "Other Data";

    private List<DataPacket> allegiantDatas = new List<DataPacket>();
    private List<DataPacket> divergentDatas = new List<DataPacket>();
    private List<DataPacket> insurgentDatas = new List<DataPacket>();
    private List<DataPacket> otherDatas = new List<DataPacket>();
    #endregion

    #region Built In Methods
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        
        PopulateDataLists();

        allegiantBtn.onClick.AddListener(delegate { ShowData("Allegiant"); });
        divergentBtn.onClick.AddListener(delegate { ShowData("Divergent"); });
        insurgentBtn.onClick.AddListener(delegate { ShowData("Insurgent"); });
        otherBtn.onClick.AddListener(delegate { ShowData("Other"); });
        exportBtn.onClick.AddListener(delegate { ExportLogs(PlayerPrefs.GetString("Path"), eventLog); });
        creditsBtn.onClick.AddListener(LoadCredits);

        ShowData(PlayerPrefs.GetString("Path"));
    }
    #endregion

    #region Custom Methods
    private void ExportLogs(string logType, List<string> logs)
    {
        string path = Application.dataPath + logType + "log.txt";
        StreamWriter writer = new StreamWriter(path);

        if (!File.Exists(path))
        {
            File.WriteAllText(path, logType + " Log \n\n");
        }

        foreach (string item in logs)
        {
            writer.WriteLine(item);
        }

        writer.Close();
    }

    private void PopulateDataLists()
    {
        foreach (var item in dataInventory.Container)
        {
            if (item.data.dataType.ToString() == "Allegiant")
            {
                allegiantDatas.Add((AllegiantData)item.data);
            }
            else if (item.data.dataType.ToString() == "Divergent")
            {
                divergentDatas.Add((DivergentData)item.data);
            }
            else if (item.data.dataType.ToString() == "Insurgent")
            {
                insurgentDatas.Add((InsurgentData)item.data);
            }
            else if (item.data.dataType.ToString() == "Other")
            {
                otherDatas.Add((OtherData)item.data);
            }
        }
    }

    private void ShowData(string path)
    {
        ClearLogs();

        switch (path)
        {
            case "Allegiant":
                SetTitle(allegiantTitle, Color.green);
                SetLogs(allegiantDatas);
                break;
            case "Divergent":
                SetTitle(divergentTitle, Color.blue);
                SetLogs(divergentDatas);
                break;
            case "Insurgent":
                SetTitle(insurgentTitle, Color.red);
                SetLogs(insurgentDatas);
                break;
            case "Other":
                SetTitle(otherTitle, new Color(225, 225, 225, 255));
                SetLogs(otherDatas);
                break;
            default:
                SetTitle(otherTitle, new Color(225, 225, 225, 255));
                SetLogs(otherDatas);
                break;
        }
    }

    private void SetLogs(List<DataPacket> datas)
    {
        foreach (var item in datas)
        {
            AddLog("<link=" + item.url + ">" + "<u><color=#71EE5F>" + item.url+ "</color></u>" + "</link>");
            AddLog(item.description);
        }
    }

    private void SetTitle(string title, Color color)
    {
        headerText.text = title;
        headerText.color = color;
    }

    public void AddLog(string newDataLog)
    {
        bool hasDuplicate = false;

        if (eventLog.Count.Equals(0))
        {
            eventLog.Add(newDataLog);
            PrintLogs();

        }
        else
        {
            for (int i = 0; i < eventLog.Count; i++)
            {
                if (newDataLog.Equals(eventLog[i]))
                {
                    hasDuplicate = true;
                    break;
                }
                else
                {
                    hasDuplicate = false;
                }
            }

            if (!hasDuplicate)
            {
                eventLog.Add(newDataLog);
                PrintLogs();
            }
        }
    }

    private void PrintLogs()
    {
        guiText = "";

        foreach (string log in eventLog)
        {
            guiText += log;
            guiText += "\n";
            guiText += "\n";
        }

        logText.text = guiText;
    }

    private void ClearLogs()
    {
        logText.text = "";
        eventLog.Clear();
    }

    private void LoadCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }
    #endregion
}