using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvolutionManager : MonoBehaviour
{
    #region Variables
    public DataInventory dataInventory;
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
            dataInventory.AddItem(data.data);
            Destroy(other.gameObject);

            Debug.Log(data.data.description);
        }
    }
    #endregion
}
