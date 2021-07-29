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