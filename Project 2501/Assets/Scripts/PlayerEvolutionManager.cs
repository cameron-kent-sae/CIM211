using System;
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
                    dataLogger.AddLog(data.data.url);
                    dataLogger.AddLog("\n");
                    dataLogger.AddLog(data.data.description);
                    dataLogger.AddLog("\n");
                    CheckAllegiantLevel();
                    break;
                case DataType.Divergent:
                    divergentCount += 1;
                    dataLogger.divCount.text = divergentCount.ToString();
                    dataLogger.AddLog(data.data.url);
                    dataLogger.AddLog("\n");
                    dataLogger.AddLog(data.data.description);
                    dataLogger.AddLog("\n");
                    CheckDivergentLevel();
                    break;
                case DataType.Insurgent:
                    insurgentCount += 1;
                    dataLogger.insCount.text = insurgentCount.ToString();
                    dataLogger.AddLog(data.data.url);
                    dataLogger.AddLog("\n");
                    dataLogger.AddLog(data.data.description);
                    dataLogger.AddLog("\n");
                    CheckInsurgentLevel();
                    break;
                case DataType.Other:
                    dataLogger.AddLog(data.data.url);
                    dataLogger.AddLog("\n");
                    dataLogger.AddLog(data.data.description);
                    dataLogger.AddLog("\n");
                    break;
                default:
                    break;
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

    private void UpdateGlobals(string path)
    {
        int topLevel = Mathf.Max(allegiantLevel, divergentLevel, insurgentLevel);

        switch (topLevel)
        {
            case 1:
                cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, 20, 5);
                mouseFollow.speed = 20;
                dataPacketSpawner.spawnRate = 0.9f;
                break;
            case 2:
                cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, 30, 5);
                mouseFollow.speed = 30;
                dataPacketSpawner.spawnRate = 0.8f;
                break;
            case 3:
                cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, 40, 5);
                mouseFollow.speed = 40;
                dataPacketSpawner.spawnRate = 0.7f;
                counterAISpawner.spawnRate = 30f;
                StartCoroutine(counterAISpawner.SpawnCounterAI());
                break;
            case 4:
                cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, 50, 5);
                mouseFollow.speed = 50;
                dataPacketSpawner.spawnRate = 0.6f;
                break;
            case 5:
                cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, 60, 5);
                mouseFollow.speed = 60;
                dataPacketSpawner.spawnRate = 0.5f;
                break;
            case 6:
                cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, 70, 5);
                mouseFollow.speed = 70;
                dataPacketSpawner.spawnRate = 0.4f;
                counterAISpawner.spawnRate = 20f;
                break;
            case 7:
                cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, 80, 5);
                mouseFollow.speed = 80;
                dataPacketSpawner.spawnRate = 0.3f;
                break;
            case 8:
                cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, 90, 5);
                mouseFollow.speed = 90;
                dataPacketSpawner.spawnRate = 0.2f;
                break;
            case 9:
                cameraRunner.speed = Mathf.Lerp(cameraRunner.speed, 100, 5);
                mouseFollow.speed = 100;
                dataPacketSpawner.spawnRate = 0.1f;
                counterAISpawner.spawnRate = 10f;
                break;
            case 10:
                // WIN THE GAME
                switch (path)
                {
                    case "Allegiant":
                        PlayerPrefs.SetString("WinPath", path);
                        WinGame();
                        break;
                    default:
                        break;
                }
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