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
    #endregion

    #region Methods
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
    #endregion
}
