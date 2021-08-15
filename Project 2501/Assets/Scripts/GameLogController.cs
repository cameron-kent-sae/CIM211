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

    public TMP_Text headerText;

    public Button allegiantBtn;
    public Button divergentBtn;
    public Button insurgentBtn;
    public Button otherBtn;
    public Button creditsBtn;

    public string creditsScene;

    private string allegiantTitle = "Allegiant Data";
    private string divergentTitle = "Divergent Data";
    private string insurgentTitle = "Insurgent Data";
    private string otherTitle = "Other Data";

    private List<AllegiantData> allegiantDatas = new List<AllegiantData>();
    private List<DivergentData> divergentDatas = new List<DivergentData>();
    private List<InsurgentData> insurgentDatas = new List<InsurgentData>();
    private List<OtherData> otherDatas = new List<OtherData>();
    #endregion

    #region Built In Methods
    private void Start()
    {
        PopulateDataLists();

        allegiantBtn.onClick.AddListener(delegate { ShowData("Allegiant"); });
        divergentBtn.onClick.AddListener(delegate { ShowData("Divergent"); });
        insurgentBtn.onClick.AddListener(delegate { ShowData("Insurgent"); });
        otherBtn.onClick.AddListener(delegate { ShowData("Other"); });
        creditsBtn.onClick.AddListener(LoadCredits);

        ShowData(PlayerPrefs.GetString("Path"));
    }
    #endregion

    #region Custom Methods
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
                headerText.text = allegiantTitle;
                headerText.color = Color.green;
                foreach (var item in allegiantDatas)
                {
                    DisplayData(item);
                }
                break;
            case "Divergent":
                headerText.text = divergentTitle;
                headerText.color = Color.blue;
                foreach (var item in divergentDatas)
                {
                    DisplayData(item);
                }
                break;
            case "Insurgent":
                headerText.text = insurgentTitle;
                headerText.color = Color.red;
                foreach (var item in insurgentDatas)
                {
                    DisplayData(item);
                }
                break;
            case "Other":
                headerText.text = otherTitle;
                headerText.color = new Color(225, 225, 225, 255);
                foreach (var item in otherDatas)
                {
                    DisplayData(item);
                }
                break;
            default:
                headerText.text = allegiantTitle;
                foreach (var item in allegiantDatas)
                {
                    DisplayData(item);
                }

                break;
        }
    }

    private void DisplayData(DataPacket item)
    {
        string url = item.url.ToString();
        string description = item.description.ToString();

        TMP_Text log = Instantiate(textPrefab, logPanel.transform.position, Quaternion.identity);
        log.transform.parent = logPanel.transform;

        log.text = url + "\n" + description + "\n";
    }

    private void ClearLogs()
    {
        foreach (Transform child in logPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void LoadCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }
    #endregion
}