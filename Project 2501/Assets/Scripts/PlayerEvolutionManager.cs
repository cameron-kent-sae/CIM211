using System.Collections.Generic;
using UnityEngine;

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

    //[Header("Path Levels")]
    private int allegiantLevel;
    private int divergentLevel;
    private int insurgentLevel;

    //[Header("Data Packet Counts")]
    private int allegiantCount;
    private int divergentCount;
    private int insurgentCount;

    //[Header("Level Thresholds")]
    private List<int> evolveTargets = new List<int> { 0, 2, 10, 26, 65, 122, 197, 325, 485, 677, 901 };

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
    }

    private void Update()
    {
        mouseFollow.distanceFromCamera = 15;
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
                    dataLogger.AddLog(data.data.url);
                    dataLogger.AddLog(data.data.description);
                    CheckAllegiantLevel();
                    break;
                case DataType.Divergent:
                    divergentCount += 1;
                    dataLogger.AddLog(data.data.url);
                    dataLogger.AddLog(data.data.description);
                    CheckDivergentLevel();
                    break;
                case DataType.Insurgent:
                    insurgentCount += 1;
                    dataLogger.AddLog(data.data.url);
                    dataLogger.AddLog(data.data.description);
                    CheckInsurgentLevel();
                    break;
                case DataType.Other:
                    dataLogger.AddLog(data.data.url);
                    dataLogger.AddLog(data.data.description);
                    break;
                default:
                    break;
            }
            dataInventory.AddItem(data.data);
            Destroy(other.gameObject);
            Debug.Log(data.data.description);
        }
    }
    #endregion

    #region Custom Methods
    private void UpdateSpeedAndRate(float i)
    {
        switch (i)
        {
            case 1:
                cameraRunner.speed = 20;
                mouseFollow.speed = 20;
                dataPacketSpawner.spawnRate = 0.9f;
                break;
            case 2:
                cameraRunner.speed = 30;
                mouseFollow.speed = 30;
                dataPacketSpawner.spawnRate = 0.8f;
                break;
            case 3:
                cameraRunner.speed = 40;
                mouseFollow.speed = 40;
                dataPacketSpawner.spawnRate = 0.7f;
                break;
            case 4:
                cameraRunner.speed = 50;
                mouseFollow.speed = 50;
                dataPacketSpawner.spawnRate = 0.6f;
                break;
            case 5:
                cameraRunner.speed = 60;
                mouseFollow.speed = 60;
                dataPacketSpawner.spawnRate = 0.5f;
                break;
            case 6:
                cameraRunner.speed = 70;
                mouseFollow.speed = 70;
                dataPacketSpawner.spawnRate = 0.4f;
                break;
            case 7:
                cameraRunner.speed = 80;
                mouseFollow.speed = 80;
                dataPacketSpawner.spawnRate = 0.3f;
                break;
            case 8:
                cameraRunner.speed = 90;
                mouseFollow.speed = 90;
                dataPacketSpawner.spawnRate = 0.2f;
                break;
            case 9:
                cameraRunner.speed = 100;
                mouseFollow.speed = 100;
                dataPacketSpawner.spawnRate = 0.1f;
                break;
            case 10:
                //
                break;
            default:
                break;
        }
    }

    private void CheckAllegiantLevel()
    {
        foreach (int target in evolveTargets)
        {
            if (allegiantCount == target)
            {
                allegiantLevel = evolveTargets.IndexOf(target);
                
                ActivateAllegiantObject();
                UpdateSpeedAndRate(allegiantLevel);
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
                UpdateSpeedAndRate(divergentLevel);
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
                UpdateSpeedAndRate(insurgentLevel);
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