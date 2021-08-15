using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEvolutionManager : MonoBehaviour
{
    #region Variables
    [Header("Game Systems")]
    public DataInventory dataInventory;
    public CameraRunner cameraRunner;
    public NarrativeController narrativeController;
    public DataPacketSpawner dataPacketSpawner;
    public DataLogger dataLogger;
    public MouseFollow mouseFollow;
    public CounterAISpawner counterAISpawner;
    public ChromeAbAdjuster chromeAbAdjuster;

    public string outroScene;

    [Header("Path Levels")]
    public int allegiantLevel;
    public int divergentLevel;
    public int insurgentLevel;

    [Header("Data Packet Counts")]
    public int allegiantCount;
    public int divergentCount;
    public int insurgentCount;

    //[Header("Level Thresholds")]
    private List<int> evolveTargets = new List<int> { };

    [Header("Evolution Objects")]
    public GameObject baseObject;
    public GameObject allegiantTop;
    public GameObject divergentTop;
    public GameObject insurgentTop;
    public GameObject[] allegiantObjects;
    public GameObject[] divergentObjects;
    public GameObject[] insurgentObjects;
    #endregion

    #region Built-in Methods
    private void Start()
    {
        allegiantCount = 0;
        divergentCount = 0;
        insurgentCount = 0;
        SetGameDifficulty();
    }

    private void Update()
    {
        mouseFollow.distanceFromCamera = 10;
    }

    private void OnApplicationQuit()
    {
        dataInventory.Container.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        var data = other.GetComponent<DataObject>();
        if (data)
        {
            switch (data.data.dataType)
            {
                case DataType.Allegiant:
                    allegiantCount += 1;
                    dataLogger.allCount.text = allegiantCount.ToString();
                    CheckAllegiantLevel();
                    break;
                case DataType.Divergent:
                    divergentCount += 1;
                    dataLogger.divCount.text = divergentCount.ToString();
                    CheckDivergentLevel();
                    break;
                case DataType.Insurgent:
                    insurgentCount += 1;
                    dataLogger.divCount.text = insurgentCount.ToString();
                    CheckInsurgentLevel();
                    break;
                case DataType.Other:
                    break;
                default:
                    break;
            }
            dataLogger.AddLog(data.data.url);
            dataLogger.AddLog("\n");
            dataLogger.AddLog(data.data.description);
            dataLogger.AddLog("\n");

            for (int i = 0; i < dataInventory.Container.Count; i++)
            {
                if (data == dataInventory.Container[i].data)
                {
                    //??
                }
            }

            dataInventory.AddItem(data.data);
            
            Destroy(other.gameObject);
        }
    }
    #endregion

    #region Custom Methods
    private void SetGameDifficulty()
    {
        string difficulty = PlayerPrefs.GetString("Difficulty");

        switch (difficulty)
        {
            case "Slow":
                evolveTargets = new List<int> { 0, 2, 10, 26, 65, 122, 197, 325, 485, 677, 901 }; // Q2.0 Option HARD
                break;
            case "Average":
                evolveTargets = new List<int> { 0, 2, 8, 19, 43, 76, 117, 183, 262, 353, 457 }; // Q1.8 Option MEDIUM
                break;
            case "Fast":
                evolveTargets = new List<int> { 0, 2, 7, 14, 29, 47, 69, 103, 142, 185, 232 }; // Q1.6 Option EASY
                break;
            default:
                evolveTargets = new List<int> { 0, 2, 7, 14, 29, 47, 69, 103, 142, 185, 232 }; // Q1.6 Option EASY
                break;
        }
    }

    private void SetRates(float speed, float dataRate, float aiRate, float cAb)
    {
        cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, speed, 5);
        mouseFollow.speed = speed;
        dataPacketSpawner.spawnRate = dataRate;
        counterAISpawner.spawnRate = aiRate;
        chromeAbAdjuster.UpdateChromaticAberration(cAb);
    }

    private void UpdateGlobals(string path)
    {
        int topLevel = Mathf.Max(allegiantLevel, divergentLevel, insurgentLevel);

        switch (topLevel)
        {
            case 1:
                SetRates(20, .9f, 30, .2f);
                break;
            case 2:
                SetRates(30, .8f, 30, .3f);
                break;
            case 3:
                SetRates(40, .7f, 30, .4f);
                StartCoroutine(counterAISpawner.SpawnCounterAI());
                break;
            case 4:
                SetRates(50, .6f, 30, .5f);
                break;
            case 5:
                SetRates(60, .5f, 26, .6f);
                break;
            case 6:
                SetRates(70, .4f, 22, .7f);
                break;
            case 7:
                SetRates(80, .3f, 18, .8f);
                break;
            case 8:
                SetRates(90, .2f, 14, .9f);
                break;
            case 9:
                SetRates(100, .1f, 10, 1);
                counterAISpawner.spawnRate = 10f;
                break;
            case 10:
                // WIN THE GAME
                PlayerPrefs.SetString("WinPath", path);
                WinGame();
                break;
            default:
                break;
        }
    }

    private void WinGame()
    {
        SceneManager.LoadScene(outroScene);
    }

    private void CheckAllegiantLevel()
    {
        foreach (int target in evolveTargets)
        {
            if (allegiantCount == target)
            {
                allegiantLevel = evolveTargets.IndexOf(target);

                ActivateAllegiantObject();
                UpdateGlobals("Allegiant");

                narrativeController.PlayNarration("allegiant", allegiantLevel);
            }
        }
    }

    private void CheckDivergentLevel()
    {
        foreach (int target in evolveTargets)
        {
            if (divergentCount == target)
            {
                divergentLevel = evolveTargets.IndexOf(target);

                ActivateDivergentObject();
                UpdateGlobals("Divergent");

                narrativeController.PlayNarration("divergent", divergentLevel);
            }
        }
    }

    private void CheckInsurgentLevel()
    {
        foreach (int target in evolveTargets)
        {
            if (insurgentCount == target)
            {
                insurgentLevel = evolveTargets.IndexOf(target);

                ActivateInsurgentObject();
                UpdateGlobals("Insurgent");

                narrativeController.PlayNarration("insurgent", insurgentLevel);
            }
        }
    }

    private void ActivateAllegiantObject()
    {
        baseObject.SetActive(false);
        allegiantTop.SetActive(true);
        allegiantObjects[allegiantLevel - 1].SetActive(true);

        if (allegiantLevel == divergentLevel || allegiantLevel > divergentLevel) { divergentTop.SetActive(false); }
        if (allegiantLevel == insurgentLevel || allegiantLevel > insurgentLevel) { insurgentTop.SetActive(false); }

        if (allegiantLevel < divergentLevel || allegiantLevel < insurgentLevel) { allegiantTop.SetActive(false); }
    }

    private void ActivateDivergentObject()
    {
        baseObject.SetActive(false);
        divergentTop.SetActive(true);
        divergentObjects[divergentLevel - 1].SetActive(true);

        if (divergentLevel == allegiantLevel || divergentLevel > allegiantLevel) { allegiantTop.SetActive(false); }
        if (divergentLevel == insurgentLevel || divergentLevel > insurgentLevel) { insurgentTop.SetActive(false); }

        if (divergentLevel < allegiantLevel || divergentLevel < insurgentLevel) { divergentTop.SetActive(false); }
    }

    private void ActivateInsurgentObject()
    {
        baseObject.SetActive(false);
        insurgentTop.SetActive(true);
        insurgentObjects[insurgentLevel - 1].SetActive(true);

        if (insurgentLevel == allegiantLevel || insurgentLevel > allegiantLevel) { allegiantTop.SetActive(false); }
        if (insurgentLevel == divergentLevel || insurgentLevel > divergentLevel) { divergentTop.SetActive(false); }

        if (insurgentLevel < allegiantLevel || insurgentLevel < divergentLevel) { insurgentTop.SetActive(false); }
    }
    #endregion
}