using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvolutionManager : MonoBehaviour
{
    #region Variables
    public DataInventory dataInventory;

    [Header("Path Levels")]
    public int allegiantLevel;
    public int divergentLevel;
    public int InsurgentLevel;

    [Header("Data Packet Counts")]
    public int allegiantCount;
    public int divergentCount;
    public int insurgentCount;

    [Header("Level Thresholds")]
    public List<int> evolveTargets = new List<int> { 2, 5, 10, 17, 26, 37, 50, 65, 82, 101 };
    #endregion

    #region Methods
    private void Start()
    {
        allegiantCount = 0;
        divergentCount = 0;
        insurgentCount = 0;
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
                    CheckAllegiantLevel();
                    break;
                case DataType.Divergent:
                    divergentCount += 1;
                    CheckDivergentLevel();
                    break;
                case DataType.Insurgent:
                    insurgentCount += 1;
                    CheckInsurgentLevel();
                    break;
                default:
                    break;
            }
            dataInventory.AddItem(data.data);
            Destroy(other.gameObject);
            Debug.Log(data.data.description);
        }
    }

    private void CheckAllegiantLevel()
    {
        foreach (int target in evolveTargets)
        {
            if (allegiantCount == target)
            {
                allegiantLevel = evolveTargets.IndexOf(target);
                //update player appearance
            }
        }
    }

    private void CheckDivergentLevel()
    {
        foreach (int target in evolveTargets)
        {
            if (divergentCount == target)
            {
                divergentCount = evolveTargets.IndexOf(target);
                //update player appearance
            }
        }
    }

    private void CheckInsurgentLevel()
    {
        foreach (int target in evolveTargets)
        {
            if (insurgentCount == target)
            {
                insurgentCount = evolveTargets.IndexOf(target);
                //update player appearance
            }
        }
    }
    #endregion
}
