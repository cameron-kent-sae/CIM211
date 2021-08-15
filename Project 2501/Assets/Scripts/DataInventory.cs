using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Inventory", menuName = "DataPacket/DataInventory")]
public class DataInventory : ScriptableObject
{
    public List<DataSlot> Container = new List<DataSlot>();

    // Add an item to the player inventory Scriptable Object
    public void AddItem(DataPacket _data)
    {
        Container.Add(new DataSlot(_data));
    }

    public void RemoveItem(DataSlot _data)
    {
    }

    public void CheckDuplicates(DataObject data)
    {
        foreach (var item in Container)
        {
            if (data.data.url == item.data.url)
            {
                Container.Remove(item);
            }
        }/*
            for (int i = 0; i < Container.Count; i++)
            {
                if (data.data.url != Container[i].data.url)
                {
                    AddItem(data.data);
                }
            }*/
    }
}

[System.Serializable]
public class DataSlot
{
    public DataPacket data;

    public DataSlot(DataPacket _data)
    {
        data = _data;
    }
}