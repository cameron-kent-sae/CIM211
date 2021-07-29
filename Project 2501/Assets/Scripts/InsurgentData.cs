using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Packet", menuName = "DataPacket/InsurgentData")]
public class InsurgentData : DataPacket
{
    private void Awake()
    {
        dataType = DataType.Insurgent;
    }
}
