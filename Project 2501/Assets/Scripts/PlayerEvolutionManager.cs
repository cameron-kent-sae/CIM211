using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvolutionManager : MonoBehaviour
{
    #region Variables
    public DataInventory dataInventory;

    public int allegiantCount;
    public int divergentCount;
    public int insurgentCount;

    public int allegiantLevel;
    public int divergentLevel;
    public int InsurgentLevel;

    //public int[] evoTargets = {0, 2, 5, 10, 17, 26, 37, 50, 65, 82, 101};
    public List<int> evoTargets = new List<int> { 2, 5, 10, 17, 26, 37, 50, 65, 82, 101 };
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
                case DataType.Divegent:
                    divergentCount += 1;
                    break;
                case DataType.Insurgent:
                    insurgentCount += 1;
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
        //if a typeCount == an evoTarget -> update player appearance
        //for (int i = 0; i < evoTargets.Length; i++)
        foreach (int target in evoTargets)
        {
            if (allegiantCount == target)
            {
                allegiantLevel = evoTargets.IndexOf(target);
            }
        }
        Debug.Log(allegiantLevel);
    }
    #endregion
}
