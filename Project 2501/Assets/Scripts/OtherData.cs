using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Packet", menuName = "DataPacket/OtherData")]
public class OtherData : DataPacket
{
    private void Awake()
    {
        dataType = DataType.Other;
    }
}