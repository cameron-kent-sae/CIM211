using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Packet", menuName = "DataPacket/DivergentData")]
public class DivergentData : DataPacket
{
    private void Awake()
    {
        dataType = DataType.Divegent;
    }
}
